namespace Exercises5_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//CheckLength(null);
			CheckLength("Hello");
		}

		static void CheckLength(string? text)
		{
			int? length = text?.Length;
			if (length == null)
			{
				Console.WriteLine("String is null");
			}
			else
			{
				Console.WriteLine($"Length: {length}");
			}
		}
	}
}