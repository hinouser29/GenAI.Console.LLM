namespace Exercises4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Nhap tong thu nhap (VND): ");
			double income1 = double.Parse(Console.ReadLine());
			Console.WriteLine(PrintTaxReport(income1));
		}
		public static string PrintTaxReport(double income)
		{
			double tax = CalculateTax(income);
			string rate = income <= 5_000_000 ? "5%" : income <= 10_000_000 ? "10%" : income <= 18_000_000 ? "15%" : "20%";
			return $"Income: {income:N0} VND\nTax ({rate}): {tax:N0} VND";
		}

		public static double CalculateTax(double income) => income switch
		{
			<= 5_000_000 => income * 0.05,
			<= 10_000_000 => income * 0.10,
			<= 18_000_000 => income * 0.15,
			_ => income * 0.20
		};
	}
}
