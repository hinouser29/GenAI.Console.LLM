namespace Exercises16
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var result = new TaxResult("Mai", 20000000, 4000000, 16000000);
			Console.WriteLine(result.NetIncome);
		}
		public record TaxResult(string Name, double Income, double Tax, double NetIncome);
	}
}
