using System;
using Geometry.Perimeter;
using Geometry.Area;

namespace Geometry.Perimeter
{
	public class CircleCalc
	{
		public static double GetPerimeter(double radius) => 2 * Math.PI * radius;
	}
}

namespace Geometry.Area
{
	public class CircleCalc
	{
		public static double GetArea(double radius) => Math.PI * Math.Pow(radius, 2);
	}
}

namespace Exercises4_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double radius = 5;
			Console.WriteLine($"Radius: {radius}");
			Console.WriteLine($"Perimeter: {Geometry.Perimeter.CircleCalc.GetPerimeter(radius):F2}");
			Console.WriteLine($"Area: {Geometry.Area.CircleCalc.GetArea(radius):F2}");
		}
	}
}
