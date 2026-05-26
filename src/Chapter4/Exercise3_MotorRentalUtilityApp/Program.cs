namespace Exercise3_MotorRentalUtilityApp
{
	public class DataVault<T>
	{
		public List<T> Items { get; set; }

		public DataVault()
		{
			Items = new List<T>();
		}

		public void Add(T item)
		{
			Items.Add(item);
		}

		public IEnumerable<T> FindAll(Func<T, bool> predicate)
		{
			return Items.FindAll(new Predicate<T>(predicate));
		}

		public void Remove(T item)
		{
			Items.Remove(item);
		}

		public int Count()
		{
			return Items.Count;
		}
	}
	public class Motorbike
	{
		public int BikeId { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public decimal DailyRate { get; set; }
		public string Status { get; set; }

		public bool IsAvailable()
		{
			return Status == "Available";
		}

		public override string ToString()
		{
			return $"[{BikeId}] {Brand} {Model} - Rate: {DailyRate} VND/day (Status: {Status})";
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			DataVault<string> notes = new DataVault<string>();

			notes.Add("Helmet included");
			notes.Add("Full tank");
			notes.Add("Insurance available");

			Console.WriteLine("===== RENTAL NOTES =====");

			foreach (string note in notes.Items)
			{
				Console.WriteLine(note);
			}

			Console.WriteLine("Total Notes: " + notes.Count());

			DataVault<Motorbike> bikes = new DataVault<Motorbike>();

			bikes.Add(new Motorbike
			{
				BikeId = 1,
				Brand = "Honda",
				Model = "Wave",
				DailyRate = 100000,
				Status = "Available"
			});

			bikes.Add(new Motorbike
			{
				BikeId = 2,
				Brand = "Yamaha",
				Model = "Exciter",
				DailyRate = 200000,
				Status = "Rented"
			});

			bikes.Add(new Motorbike
			{
				BikeId = 3,
				Brand = "Suzuki",
				Model = "Raider",
				DailyRate = 180000,
				Status = "Available"
			});

			bikes.Add(new Motorbike
			{
				BikeId = 4,
				Brand = "Honda",
				Model = "Vision",
				DailyRate = 150000,
				Status = "Maintenance"
			});

			Console.WriteLine("\n===== MOTORBIKE LIST =====");

			foreach (Motorbike bike in bikes.Items)
			{
				Console.WriteLine(bike);
			}

			Console.WriteLine("\n===== AVAILABLE BIKES =====");

			var availableBikes = bikes.FindAll(b => b.IsAvailable());

			foreach (var bike in availableBikes)
			{
				Console.WriteLine(bike);
			}
		}
	}
}
