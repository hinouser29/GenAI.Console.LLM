using System.Drawing;

namespace Exercises10_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Point point = new Point(3, 4);
			Console.WriteLine($"Distance to origin: {point.GetDistanceToOrigin():F2}");
		}
	}
	struct Point(double x, double y)
	{
		public double GetDistanceToOrigin()
		{
			return Math.Sqrt(x * x + y * y);
		}
	}
}
