namespace Exercises8
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"=> MillionRateTax(15M * 15%): {MillionRateTax():N0} VND");
		}

		public static double MillionRateTax()
		{
			return 15_000_000 * 0.15;
		}
	}
}
