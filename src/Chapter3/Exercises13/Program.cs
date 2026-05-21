namespace Exercises13
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var e = new Employee("Trang") { Income = 12_000_000 };
			Console.WriteLine(e.Name);
		}
	}
	public interface ITaxable
	{
		public double GetTaxRate() => 0.1;
	}
	public class Employee : ITaxable
	{
		public string Name { get; }
		public double Income { get; set; }

		public Employee(string name)
		{
			Name = name;
		}
	}
}
