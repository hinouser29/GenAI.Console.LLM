namespace Exercises2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Nhap tong thu nhap (VND): ");
			double income2 = double.Parse(Console.ReadLine());
			Console.Write("Nhap so nguoi phu thuoc: ");
			int dependents = int.Parse(Console.ReadLine());
			double taxToPay = CalculateNetIncome(income2, dependents);
			Console.WriteLine($"Thue phai nop sau giam tru: {taxToPay:N0} VND");
		}
		public static double CalculateNetIncome(double income, int dependents)
		{
			double taxableIncome = income - 11_000_000 - (dependents * 4_400_000);
			if (taxableIncome <= 0) return 0;
			return CalculateTax(taxableIncome);
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
