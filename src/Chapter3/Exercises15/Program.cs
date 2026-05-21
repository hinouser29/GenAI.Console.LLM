namespace Exercises15
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var p = new TaxPayer { Income = 9_000_000 };
			Console.WriteLine(p.Calculate());
		}
		public class TaxPayer
		{
			public double Income { get; set; }

			public double Calculate() => Income * 0.1;
		}
	}
}
