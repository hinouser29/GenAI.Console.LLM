namespace Exercises10_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person("Eve", 27);
			person.PrintInfo();
		}
	}
	class Person(string name, int age)
	{
		public void PrintInfo()
		{
			Console.WriteLine($"Name: {name}, Age: {age}");
		}
	}
}
