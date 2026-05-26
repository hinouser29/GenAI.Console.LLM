namespace Exercise1
{
	public class MyGenerics<T>
	{
		public List<T> Items { get; set; }

		public MyGenerics()
		{
			Items = new List<T>();
		}

		public void Add(T item)
		{
			Items.Add(item);
		}

		public IEnumerable<T> GetAll()
		{
			return Items;
		}
	}
	public class Student
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public double MarkJava { get; set; }
		public double MarkWeb { get; set; }
		public double MarkSql { get; set; }

		public double SumMark()
		{
			return MarkJava + MarkWeb + MarkSql;
		}

		public double AvgMark()
		{
			return SumMark() / 3;
		}

		public override string ToString()
		{
			return $"{ID} - {Name} - {MarkJava} - {MarkWeb} - {MarkSql} - {SumMark()} - {AvgMark():0.00}";
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			MyGenerics<double> numbers = new MyGenerics<double>();

			numbers.Add(10.5);
			numbers.Add(20.7);
			numbers.Add(30.9);

			Console.WriteLine("===== DOUBLE VALUES =====");

			foreach (double n in numbers.GetAll())
			{
				Console.WriteLine(n);
			}

			MyGenerics<Student> students = new MyGenerics<Student>();

			students.Add(new Student
			{
				ID = 1,
				Name = "An",
				MarkJava = 8,
				MarkWeb = 7.5,
				MarkSql = 9
			});

			students.Add(new Student
			{
				ID = 2,
				Name = "Binh",
				MarkJava = 6,
				MarkWeb = 8,
				MarkSql = 7
			});

			students.Add(new Student
			{
				ID = 3,
				Name = "Cuong",
				MarkJava = 9,
				MarkWeb = 9,
				MarkSql = 8.5
			});

			Console.WriteLine("\n===== STUDENT LIST =====");

			foreach (Student s in students.GetAll())
			{
				Console.WriteLine(s);
			}
		}
	}
}
