using static Exercises11.Program;

namespace Exercises11
{
	internal class Program
	{
		static void Main(string[] args)
		{	
			TaxPayer p = new TaxPayer { Income = 10_000_000 };
			Console.WriteLine(p.CalculateTax());
		}
	}
	public class TaxPayer
	{
		public string Name { get; set; }
		public double Income { get; set; }
		public int Dependents { get; set; }
	}
	public static class TaxExtensions
	{
		public static double CalculateTax(this TaxPayer taxpayer)
		{
			return taxpayer.Income * 0.1;
		}
	}
}
