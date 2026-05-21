namespace Exercises6_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { 1, 2, 3, 4 };
			int index = 2;
			ref int elementRef = ref numbers[index];
			elementRef = 10;
			Console.WriteLine("Array after modification:");
			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}
