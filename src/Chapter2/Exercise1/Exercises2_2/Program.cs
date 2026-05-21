namespace Exercises2_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int totalSum = CalculateSum(1, 2, 3, 4, 5);
			Console.WriteLine($"Sum: {totalSum}");
		}
		static int CalculateSum(params int[] numbers)
		{
			int sum = 0;
			foreach (int num in numbers)
			{
				sum += num;
			}
			return sum;
		}
	}
}
