namespace Exercises17
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TaxPayer p = new TaxPayer { Name = "Duc", Income = 8000000, Dependents = 0 };
			Console.WriteLine(p.Income);
		}
		public class TaxPayer
		{
			public string Name { get; set; }
			public double Income { get; set; }
			public int Dependents { get; set; }
		}
	}
}
