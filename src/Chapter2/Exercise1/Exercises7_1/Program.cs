namespace Exercises7_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var student = ("Bob", 22, 3.8);
			var (_, age, _) = student;
			Console.WriteLine($"Age: {age}");
		}
	}
}
