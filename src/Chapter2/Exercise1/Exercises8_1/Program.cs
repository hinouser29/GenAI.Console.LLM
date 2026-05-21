namespace Exercises8_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int largeNumber = 1_000_000;
			int otherNumber = 500_000;
			int sum = largeNumber + otherNumber;
			Console.WriteLine($"Sum: {sum:N0}");
		}
	}
}
