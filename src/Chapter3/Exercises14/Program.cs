using System;
using System.IO;

namespace Exercises14
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ReadIncomeData("data.txt");
		}
	
	public static void ReadIncomeData(string filePath)
		{
			using StreamReader reader = new StreamReader(filePath);
			string content = reader.ReadToEnd();
			Console.WriteLine(content);
		}
	}
}
