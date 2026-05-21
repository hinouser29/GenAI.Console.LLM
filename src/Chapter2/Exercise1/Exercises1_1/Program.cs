using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises1_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var numbers = new List<int> { 5, 12, 8, 15, 3, 20 };
			var filteredNumbers = numbers.Where(n => n > 10);
			Console.WriteLine("Numbers greater than 10:");
			Console.WriteLine(string.Join(" ", filteredNumbers));
		}
	}
}
