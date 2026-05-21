namespace Exercises5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Do you want to enter taxpayer information? (y/n): ");
			string choice = Console.ReadLine().ToLower();

			TaxPayer? payer = null;
			if (choice == "y")
			{
				payer = new TaxPayer();
				Console.Write("Name = ");
				payer.Name = Console.ReadLine();
				Console.Write("Income = ");
				payer.Income = double.Parse(Console.ReadLine());
			}
			Console.WriteLine(GenerateMessage(payer));
		}
		public class TaxPayer
		{
			public string? Name { get; set; }
			public double Income { get; set; }
		}

		public static string GenerateMessage(TaxPayer? person)
		{
			string name = person?.Name ?? "Guest";
			double income = person?.Income ?? 0;
			return $"Hello {name}, your income is {income:N0} VND.";
		}
	}
}
