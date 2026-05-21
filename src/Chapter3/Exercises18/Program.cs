namespace Exercises18
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var c = new Citizen { Name = "Lien", Income = 18_000_000 };
			Console.WriteLine(c.Name);
		}
		public record Citizen
		{
			public string Name { get; init; }
			public double Income { get; init; }
		}
	}
}
