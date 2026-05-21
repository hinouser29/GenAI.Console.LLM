namespace Exercises6_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { 5, 2, 8, 1, 9 };
			ref int maxElement = ref FindMaxReference(numbers);
			maxElement = 100;
			Console.WriteLine("Array after modifying max:");
			Console.WriteLine(string.Join(" ", numbers));
		}

		static ref int FindMaxReference(int[] arr)
		{
			int maxIndex = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] > arr[maxIndex])
				{
					maxIndex = i;
				}
			}
			return ref arr[maxIndex];
		}
	}
}
