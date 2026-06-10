using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Program
{
    public static async Task Main()
    {
        // 1. Tìm file Calculator.cs đi ngược lên từ thư mục thực thi bin
        string? calculatorPath = FindUpwardFile(AppContext.BaseDirectory, "Calculator.cs");
        if (calculatorPath == null) 
        { 
            Console.WriteLine("Lỗi: Không tìm thấy file Calculator.cs!"); 
            return; 
        }
        
        Console.WriteLine($"Đã tìm thấy file Calculator tại: {calculatorPath}");
        string methodCode = await File.ReadAllTextAsync(calculatorPath, Encoding.UTF8);

        // 2. Chuẩn bị prompt gửi cho Local LLM
        var prompt = $"""
Write a real xUnit test for the following C# method.
Do not use Moq or mocking. Just create a real test that calls the method and asserts the result.

Code:
{methodCode}
""";

        // 3. Cấu hình HttpClient gửi request tới LM Studio (Timeout 6 phút)
        using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(6) };
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "lm-studio");

        var body = new
        {
            model = "openai/gpt-oss-20b",
            messages = new[] { new { role = "user", content = prompt } },
            max_tokens = 400,
            stream = false,
            temperature = 0.2
        };

        var json = System.Text.Json.JsonSerializer.Serialize(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            Console.WriteLine("Đang gửi yêu cầu tới LM Studio API (http://localhost:1234)...");
            var resp = await client.PostAsync("http://localhost:1234/v1/chat/completions", content);
            resp.EnsureSuccessStatusCode();

            var responseText = await resp.Content.ReadAsStringAsync();
            
            // 4. Phân tích kết quả JSON bằng Newtonsoft.Json
            var raw = JObject.Parse(responseText)["choices"]![0]!["message"]!["content"]!.ToString();
            string unitTestCode = StripCodeFence(raw);

            // 5. Xác định thư mục lưu trữ UnitTest và ghi tệp UnitTest_Generated.cs
            var unitTestDir = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(calculatorPath)!, "..", "UnitTest"));
            Directory.CreateDirectory(unitTestDir);
            
            string outFile = Path.Combine(unitTestDir, "UnitTest_Generated.cs");
            await File.WriteAllTextAsync(outFile, unitTestCode, Encoding.UTF8);
            
            Console.WriteLine($"Sinh mã thành công! Đã lưu file test tại: {outFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi trong quá trình xử lý: {ex.Message}");
            Console.WriteLine("Vui lòng kiểm tra xem bạn đã Start Server trong LM Studio ở cổng 1234 chưa.");
        }
    }

    // Hàm quét ngược tìm kiếm file nguồn
    public static string? FindUpwardFile(string start, string name, int max = 8)
    {
        var d = new DirectoryInfo(start);
        for (int i = 0; i < max && d != null; i++, d = d.Parent)
        {
            string c = Path.Combine(d.FullName, name);
            if (File.Exists(c)) return c;
        }
        return null;
    }

    // Hàm làm sạch Markdown Code Block
    public static string StripCodeFence(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return s;
        int a = s.IndexOf("```");
        if (a >= 0)
        {
            int b = s.IndexOf("```", a + 3);
            if (b > a) s = s.Substring(a + 3, b - a - 3);
            s = s.Replace("csharp", "").Replace("cs", "");
        }
        return s.Trim();
    }
}
