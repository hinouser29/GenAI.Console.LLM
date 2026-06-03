using System;

namespace PersonalIncomeTaxSystem
{
	// ==========================================
	// TASK 1: định nghĩa Singleton class TaxConfig
	// ==========================================
	public sealed class TaxConfig
	{
		private static TaxConfig _instance = null;
		private static readonly object _lock = new object();

		public double StandardDeduction { get; } = 11000000;
		public double DependentAllowance { get; } = 4400000;

		private TaxConfig() { }

		public static TaxConfig Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new TaxConfig();
					}
					return _instance;
				}
			}
		}
	}

	// ==========================================
	// TASK 2: định nghĩa abstract class Employee
	// ==========================================
	public abstract class Employee
	{
		public string Name { get; set; }
		public int Dependents { get; set; }

		protected Employee(string name, int dependents)
		{
			Name = name;
			Dependents = dependents;
		}

		public abstract double GetIncome();

		public double CalculateTax()
		{
			double income = GetIncome();
			TaxConfig config = TaxConfig.Instance;

			double taxableIncome = income - config.StandardDeduction - (config.DependentAllowance * Dependents);

			if (taxableIncome <= 0) return 0;

			double tax = 0;

			if (taxableIncome <= 5000000)
			{
				tax = taxableIncome * 0.05;
			}
			else if (taxableIncome <= 10000000)
			{
				tax = (5000000 * 0.05) + ((taxableIncome - 5000000) * 0.1);
			}
			else if (taxableIncome <= 18000000)
			{
				tax = (5000000 * 0.05) + (5000000 * 0.1) + ((taxableIncome - 10000000) * 0.15);
			}
			else
			{
				tax = (5000000 * 0.05) + (5000000 * 0.1) + (8000000 * 0.15) + ((taxableIncome - 18000000) * 0.2);
			}

			return tax;
		}
	}

	// ==========================================
	// TASK 3: lớp OfficeEmployee mở rộng Employee
	// ==========================================
	public class OfficeEmployee : Employee
	{
		public double DayIncome { get; set; }
		public double NumberOfDays { get; set; }

		public OfficeEmployee(string name, int dependents, double dayIncome, double numberOfDays)
			: base(name, dependents)
		{
			DayIncome = dayIncome;
			NumberOfDays = numberOfDays;
		}

		public override double GetIncome()
		{
			return DayIncome * NumberOfDays;
		}
	}

	// ==========================================
	// TASK 4: lớp Freelancer mở rộng Employee
	// ==========================================
	public class Freelancer : Employee
	{
		public double MonthlyIncome { get; set; }
		public double Expense { get; set; }

		public Freelancer(string name, int dependents, double monthlyIncome, double expense)
			: base(name, dependents)
		{
			MonthlyIncome = monthlyIncome;
			Expense = expense;
		}

		public override double GetIncome()
		{
			return MonthlyIncome - Expense;
		}
	}

	// ==========================================
	// TASK 5: triển khai EmployeeFactory
	// ==========================================
	public static class EmployeeFactory
	{
		public static Employee CreateEmployee(string type, string name, int dependents, double param1, double param2)
		{
			switch (type.ToLower())
			{
				case "officeemployee":
					return new OfficeEmployee(name, dependents, param1, param2);
				case "freelancer":
					return new Freelancer(name, dependents, param1, param2);
				default:
					throw new ArgumentException("Loại nhân viên không hợp lệ.");
			}
		}
	}

	// ==========================================
	// TASK 6: hàm Main để chạy thử nghiệm và in kết quả
	// ==========================================
	class Program
	{
		static void Main(string[] sender)
		{
			TaxConfig config = TaxConfig.Instance;
			Console.WriteLine($"Standard Deduction: {config.StandardDeduction:N0} | Dependent Allowance: {config.DependentAllowance:N0}");
			Console.WriteLine(new string('-', 80));

			Employee emp1 = EmployeeFactory.CreateEmployee("OfficeEmployee", "John Doe", 0, 200000, 24);

			Employee emp2 = EmployeeFactory.CreateEmployee("Freelancer", "Mary Doe", 0, 10000000, 2000000);

			PrintEmployeeDetails(emp1);
			PrintEmployeeDetails(emp2);

			Console.ReadLine();
		}

		static void PrintEmployeeDetails(Employee emp)
		{
			string typeName = emp.GetType().Name;
			Console.WriteLine($"Name: {emp.Name} | Type: {typeName} | Income: {emp.GetIncome():N0} | Tax: {emp.CalculateTax():N0}");
		}
	}
}