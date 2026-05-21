namespace Exercises5_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person(null, 25);
			person.PrintInfo();
		}
	}

	class Person
	{
		public string? Name { get; set; }
		public int Age { get; set; }
		public Person(string? name, int age)
		{
			Name = name;
			Age = age;
		}
		public void PrintInfo()
		{
			string displayName = Name ?? "Unknown";
			Console.WriteLine($"Name: {displayName}, Age: {Age}");
		}
	}
}
