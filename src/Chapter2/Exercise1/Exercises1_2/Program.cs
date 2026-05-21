namespace Exercises1_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			dynamic data = new System.Dynamic.ExpandoObject();
			data.Text = "Hello";
			data.Number = 5;
			data.Text += " World";
			data.Number += 10;
			Console.WriteLine($"Text: {data.Text}");
			Console.WriteLine($"Number: {data.Number}");
			try
			{
				Console.WriteLine(data.NonExistent);
			}
			catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
			{
				Console.WriteLine("Error: 'AnonymousType#1' does not contain a definition for 'NonExistent'");
			}
		}
	}
}
