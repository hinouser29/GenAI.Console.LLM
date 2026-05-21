namespace Exercises7
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter income (VND): ");
			double income = double.Parse(Console.ReadLine() ?? "0");

			Console.WriteLine($"=> Income Level: {IncomeLevel(income)}");
		}
		public static string IncomeLevel(double income) => income switch
		{
			<= 4_500_000 => "Low",
			_ => "_"  
		};
	}
}
