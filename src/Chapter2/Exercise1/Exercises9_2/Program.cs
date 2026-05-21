namespace Exercises9_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var personTuple = ("David", 28);
			var (name, age) = personTuple;
			Console.WriteLine($"Name: {name}");
			Console.WriteLine($"Age: {age}");
		}
	}
}
