namespace Exercises7_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Classify("Test");
			Classify(42);
		}
		static void Classify(object obj)
		{
			string result = obj switch
			{
				string s => $"String: {s}",
				int i => $"Integer: {i}",
				_ => "Unknown Type"
			};
			Console.WriteLine(result);
		}
	}
}
