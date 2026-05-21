namespace Exercises3_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintSquare(4);
		}
		static void PrintSquare(int number)
		{
			static int Square(int n) => n * n;
			Console.WriteLine($"Square of {number}: {Square(number)}");
		}
	}
}
