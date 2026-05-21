namespace Exercises9
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter income (VND): ");
			double income = double.Parse(Console.ReadLine() ?? "0");

			var result = TaxAndNet(income);

			Console.WriteLine($"=> tax: {result.tax:N0} VND");
			Console.WriteLine($"=> net income: {result.netIncome:N0} VND");
		}
		public static (double tax, double netIncome) TaxAndNet(double income)
		{
			double tax = income switch
			{
				<= 5_000_000 => income * 0.05,
				<= 10_000_000 => income * 0.10,
				<= 18_000_000 => income * 0.15,
				_ => income * 0.20
			};

			double netIncome = income - tax;

			return (tax, netIncome);
		}
	}
}
