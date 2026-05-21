namespace Exercises8_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number = 0b1100;
			Console.WriteLine($"Number: {number}");
			Console.WriteLine($"Is even: {number % 2 == 0}");
		}
	}
}
