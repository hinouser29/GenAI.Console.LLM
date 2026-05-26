namespace Exercise2_PatientRecordApp
{
	public class MedicalRecord<T>
	{
		public List<T> Records { get; set; }

		public MedicalRecord()
		{
			Records = new List<T>();
		}

		public void AddRecord(T record)
		{
			Records.Add(record);
		}

		public IEnumerable<T> GetAllRecords()
		{
			return Records;
		}

		public void RemoveRecord(T record)
		{
			Records.Remove(record);
		}

		public int GetRecordCount()
		{
			return Records.Count;
		}
	}
	public class Patient
	{
		public int PatientID { get; set; }
		public string FullName { get; set; }
		public int Age { get; set; }
		public string BloodType { get; set; }
		public decimal TreatmentCost { get; set; }

		public string GetAgeCategory()
		{
			if (Age < 18)
				return "Child";
			else if (Age <= 65)
				return "Adult";
			else
				return "Senior";
		}

		public override string ToString()
		{
			return $"{PatientID} - {FullName} ({Age} years, {BloodType}) - Cost: ${TreatmentCost}";
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			MedicalRecord<string> diagnoses = new MedicalRecord<string>();

			diagnoses.AddRecord("Flu");
			diagnoses.AddRecord("Diabetes");
			diagnoses.AddRecord("COVID-19");

			Console.WriteLine("===== DIAGNOSIS LIST =====");

			foreach (string d in diagnoses.GetAllRecords())
			{
				Console.WriteLine(d);
			}

			Console.WriteLine("Total: " + diagnoses.GetRecordCount());

			MedicalRecord<Patient> patients = new MedicalRecord<Patient>();

			patients.AddRecord(new Patient
			{
				PatientID = 1,
				FullName = "Nguyen Van A",
				Age = 20,
				BloodType = "A",
				TreatmentCost = 150
			});

			patients.AddRecord(new Patient
			{
				PatientID = 2,
				FullName = "Tran Thi B",
				Age = 10,
				BloodType = "B",
				TreatmentCost = 200
			});

			patients.AddRecord(new Patient
			{
				PatientID = 3,
				FullName = "Le Van C",
				Age = 70,
				BloodType = "O",
				TreatmentCost = 300
			});

			patients.AddRecord(new Patient
			{
				PatientID = 4,
				FullName = "Pham Thi D",
				Age = 40,
				BloodType = "AB",
				TreatmentCost = 250
			});

			Console.WriteLine("\n===== PATIENT LIST =====");

			foreach (Patient p in patients.GetAllRecords())
			{
				Console.WriteLine(p);
				Console.WriteLine("Category: " + p.GetAgeCategory());
			}
		}
	}
}
