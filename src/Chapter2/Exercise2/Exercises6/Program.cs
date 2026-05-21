namespace Exercises6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[] incomes = { 5_000_000, 10_000_000 };
			Console.WriteLine($"Array: [{string.Join(", ", incomes.Select(i => i.ToString("N0")))}]");

			Console.Write("Enter the income you want to search: ");
			double target = double.Parse(Console.ReadLine() ?? "0");

			try
			{
				ref double incomeRef = ref FindIncomeRef(incomes, target);

				Console.Write("Found! Enter the new value to update directly in the array: ");
				double newValue = double.Parse(Console.ReadLine() ?? "0");

				incomeRef = newValue;

				Console.WriteLine($"Array after modification: [{string.Join(", ", incomes.Select(i => i.ToString("N0")))}]");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public static ref double FindIncomeRef(double[] incomes, double target)
		{
			for (int i = 0; i < incomes.Length; i++)
			{
				if (incomes[i] == target)
				{
					return ref incomes[i];
				}
			}
			throw new ArgumentException("Target income not found in the array.");
		}
	}
}
