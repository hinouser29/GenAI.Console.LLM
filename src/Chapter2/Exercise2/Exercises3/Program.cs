namespace Exercises3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Nhap tong thu nhap (VND): ");
			double income1 = double.Parse(Console.ReadLine());
			Console.WriteLine(CalculateTaxWithLocal(income1));
		}
		public static double CalculateTaxWithLocal(double income)
		{
			static bool IsValid(double inc) => inc >= 0;
			double GetTax() => CalculateTax(income);
			if (!IsValid(income)) return 0;
			return GetTax();
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
