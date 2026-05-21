namespace Exercises2_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int x = 5;
			ModifyValues(ref x, out int sum);
			Console.WriteLine($"Doubled ref value: {x}");
			Console.WriteLine($"Sum (out): {sum}");
		}

		static void ModifyValues(ref int refParam, out int outParam)
		{
			int originalValue = refParam;
			refParam *= 2;
			outParam = originalValue + refParam;
		}
	}
}
