using Exercise1_Delegates.Delegates_LINQ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1_Delegates
{
	public delegate void MyDelegate();

	class Program
	{
		static void SayHello() => Console.WriteLine("Hello from delegate!");

		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			Console.WriteLine("=== 1. DEMO DELEGATE ===");
			MyDelegate d = SayHello;
			d();


			Console.WriteLine("\n=== 2. DEMO EVENT ===");
			Notifier notifier = new Notifier();

			notifier.OnNotify += () => Console.WriteLine("Sự kiện (Event) đã được kích hoạt thành công!");

			notifier.Trigger();


			Console.WriteLine("\n=== 3. DEMO LAMBDA FILTERING ===");
			List<int> nums = new List<int> { 1, 2, 3, 4, 5 };

			var evens = nums.Where(n => n % 2 == 0);
			Console.Write("Các số chẵn tìm thấy: ");
			foreach (var n in evens)
			{
				Console.Write(n + " ");
			}
			Console.WriteLine();


			Console.WriteLine("\n=== 4. DEMO LINQ TO OBJECT ===");
			List<string> words = new List<string> { "apple", "banana", "grape", "orange" };

			var result = from w in words
						 where w.Length > 5
						 select w;

			Console.Write("Từ có trên 5 ký tự: ");
			foreach (var w in result)
			{
				Console.Write(w + " ");
			}
			Console.WriteLine();


			Console.WriteLine("\n=== 5. DEMO FUNC AND ACTION ===");
			Func<int, int, int> multiply = (a, b) => a * b;

			Action<string> print = s => Console.WriteLine(s);

			int tich = multiply(3, 4);
			Console.WriteLine($"Kết quả phép nhân (Sử dụng Func): {tich}");
			print("Xin chào từ Action Delegate!");


			Console.WriteLine("\n=== 6. DEMO COMBINE ALL (TỔNG HỢP) ===");
			DataManager dm = new DataManager();

			dm.OnLargeQuery += list => {
				Console.WriteLine($"[CẢNH BÁO EVENT]: Đã tìm thấy một lượng lớn phần tử thỏa mãn ({list.Count} phần tử)!");
			};

			for (int i = 1; i <= 8; i++)
			{
				dm.Add(i);
			}

			Console.WriteLine("--- Thực hiện lọc số chẵn ---");
			var evenNumbers = dm.Filter(n => n % 2 == 0);

			Console.Write("Kết quả tập số chẵn: ");
			foreach (var n in evenNumbers)
			{
				Console.Write(n + " ");
			}
			Console.WriteLine();

			Console.ReadLine();
		}
	}
}
