namespace Exercises9_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var person = GetPersonInfo();
			Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
		}
		static (string Name, int Age) GetPersonInfo()
		{
			return ("Charlie", 30);
		}
	}
}
