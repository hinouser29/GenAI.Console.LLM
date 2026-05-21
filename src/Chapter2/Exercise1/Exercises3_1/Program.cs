namespace Exercises3_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintFactorial(5);
		}

		static void PrintFactorial(int number)
		{
			int Factorial(int n)
			{
				if (n <= 1) return 1;
				return n * Factorial(n - 1);
			}
			Console.WriteLine($"Factorial of {number}: {Factorial(number)}");
		}
	}
}
