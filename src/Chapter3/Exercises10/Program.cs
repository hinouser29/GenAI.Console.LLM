namespace Exercises10
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TaxPayer p = new TaxPayer { Name = "Tuan", Income = 15000000, Dependents = 1 };
			Console.WriteLine(p.Name);
		}
		public class TaxPayer
		{
			public string Name { get; set; }
			public double Income { get; set; }
			public int Dependents { get; set; }
		}
	}
}
