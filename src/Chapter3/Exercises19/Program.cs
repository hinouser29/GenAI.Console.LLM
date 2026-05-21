namespace Exercises19
{
	internal class Program
	{
		static void Main(string[] args)
		{
			EmployeeTaxPayer emp = new EmployeeTaxPayer
			{
				Name = "Huy",
				Income = 9000000,
				Position = "Developer"
			};
			Console.WriteLine(emp.CalculateTax());
		}
		public class BaseTaxPayer
		{
			public string Name { get; set; }
			public double Income { get; set; }
			public virtual double CalculateTax() => Income * 0.05;
		}

		public class EmployeeTaxPayer : BaseTaxPayer
		{
			public string Position { get; set; }
			public override double CalculateTax() => Income * 0.1;
		}
	}
}
