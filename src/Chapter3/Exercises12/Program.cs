namespace Exercises12
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var summary = new { Name = "Minh", Tax = 2000000 };
			Console.WriteLine(summary.Tax);
		}

		public class TaxSummary
		{
			public string SummaryName { get; set; }
			public double TotalTax { get; set; }

			public TaxSummary() { }
		}
	}
}
