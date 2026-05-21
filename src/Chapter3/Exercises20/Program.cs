namespace Exercises20
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<ITaxable> people = new()
			{
				new Freelancer { Income = 8000000 },
				new CompanyEmployee { Income = 12000000 }
			};
			foreach (var p in people)
			{
				Console.WriteLine(p.CalculateTax());
			}
		}
	}
		public interface ITaxable
		{
			double CalculateTax();
		}

	public class Freelancer : ITaxable
	{
		public double Income { get; set; }
		public double CalculateTax() => Income * 0.1;
	}

		public class CompanyEmployee : ITaxable
		{
			public double Income { get; set; }
			public double CalculateTax() => Income * 0.15;
		}
}
