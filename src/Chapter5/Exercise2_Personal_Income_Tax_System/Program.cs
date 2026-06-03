using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2_Personal_Income_Tax_System
{
	// ==========================================
	// SINGLETON: Cấu hình thuế (Từ phần trước)
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
					if (_instance == null) _instance = new TaxConfig();
					return _instance;
				}
			}
		}
	}

	// ==========================================
	// TASK 1: Định nghĩa lớp TaxRecord
	// ==========================================
	public class TaxRecord
	{
		public DateTime Month { get; set; }
		public double Income { get; set; }
		public double TaxPaid { get; set; }

		public TaxRecord(DateTime month, double income, double taxPaid)
		{
			Month = month;
			Income = income;
			TaxPaid = taxPaid;
		}
	}

	// ==========================================
	// TASK 2: Sửa đổi abstract class Employee
	// ==========================================
	public abstract class Employee
	{
		public string Name { get; set; }
		public int Dependents { get; set; }

		public List<TaxRecord> TaxHistory { get; set; } = new List<TaxRecord>();

		protected Employee(string name, int dependents)
		{
			Name = name;
			Dependents = dependents;
		}

		public abstract double GetIncome();

		public virtual void SetMonthlyIncome(DateTime month, double amount)
		{
			var record = TaxHistory.FirstOrDefault(r => r.Month.Year == month.Year && r.Month.Month == month.Month);
			if (record != null)
			{
				record.Income = amount;
			}
			else
			{
				TaxHistory.Add(new TaxRecord(month, amount, 0));
			}
		}

		public void CalculateMonthlyTax(DateTime month)
		{
			double monthlyIncome = GetIncome();

			TaxConfig config = TaxConfig.Instance;
			double taxableIncome = monthlyIncome - config.StandardDeduction - (config.DependentAllowance * Dependents);

			double taxPaid = 0;
			if (taxableIncome > 0)
			{
				taxPaid = ApplyProgressiveTaxLogic(taxableIncome, isAnnual: false);
			}

			var existingRecord = TaxHistory.FirstOrDefault(r => r.Month.Year == month.Year && r.Month.Month == month.Month);
			if (existingRecord != null)
			{
				existingRecord.Income = monthlyIncome;
				existingRecord.TaxPaid = taxPaid;
			}
			else
			{
				TaxHistory.Add(new TaxRecord(month, monthlyIncome, taxPaid));
			}
		}

		public void CalculateAnnualTax()
		{
			TaxConfig config = TaxConfig.Instance;

			double totalIncome = TaxHistory.Sum(r => r.Income);
			double totalTaxPaid = TaxHistory.Sum(r => r.TaxPaid);

			double annualStandardDeduction = config.StandardDeduction * 12;
			double annualDependentAllowance = (config.DependentAllowance * Dependents) * 12;

			double annualTaxableIncome = totalIncome - annualStandardDeduction - annualDependentAllowance;

			double annualTaxLiability = 0;
			if (annualTaxableIncome > 0)
			{
				annualTaxLiability = ApplyProgressiveTaxLogic(annualTaxableIncome, isAnnual: true);
			}

			double diff = annualTaxLiability - totalTaxPaid;

			Console.WriteLine($"Name: {Name}");
			Console.WriteLine($"Total Income: {totalIncome:N0}");
			Console.WriteLine($"Total Tax Paid: {totalTaxPaid:N0}");
			Console.WriteLine($"Annual Tax Owed: {annualTaxLiability:N0}");

			if (diff > 0)
			{
				Console.WriteLine($"-> Underpaid Tax: {diff:N0} (Employee owes tax)");
			}
			else if (diff < 0)
			{
				Console.WriteLine($"-> Overpaid Tax: {Math.Abs(diff):N0} (Employee is due a refund)");
			}
			else
			{
				Console.WriteLine($"-> Tax Balanced: 0");
			}
		}

		private double ApplyProgressiveTaxLogic(double taxableIncome, bool isAnnual)
		{
			double factor = isAnnual ? 12 : 1;

			double b1 = 5000000 * factor;
			double b2 = 10000000 * factor;
			double b3 = 18000000 * factor;

			double tax = 0;

			if (taxableIncome <= b1)
			{
				tax = taxableIncome * 0.05;
			}
			else if (taxableIncome <= b2)
			{
				tax = (b1 * 0.05) + ((taxableIncome - b1) * 0.1);
			}
			else if (taxableIncome <= b3)
			{
				tax = (b1 * 0.05) + ((b2 - b1) * 0.1) + ((taxableIncome - b2) * 0.15);
			}
			else
			{
				tax = (b1 * 0.05) + ((b2 - b1) * 0.1) + ((b3 - b2) * 0.15) + ((taxableIncome - b3) * 0.2);
			}

			return tax;
		}
	}

	// ==========================================
	// TASK 3: Giữ tính đa hình tại subclasses
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

		public override double GetIncome() => DayIncome * NumberOfDays;
	}

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

		public override double GetIncome() => MonthlyIncome - Expense;
	}

	// ==========================================
	// TASK 4: Hàm Main giả lập dữ liệu 12 tháng
	// ==========================================
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			OfficeEmployee john = new OfficeEmployee("John Doe", 0, 1000000, 22);

			for (int month = 1; month <= 12; month++)
			{
				DateTime currentMonth = new DateTime(2026, month, 1);

				if (month == 6)
				{
					john.NumberOfDays = 35;
				}
				else if (month == 12)
				{
					john.NumberOfDays = 15;
				}
				else
				{
					john.NumberOfDays = 22;
				}

				john.CalculateMonthlyTax(currentMonth);
			}

			Console.WriteLine("=== ANNUAL PERSONAL INCOME TAX REPORT ===");
			john.CalculateAnnualTax();
			Console.WriteLine("=========================================");

			Console.ReadLine();
		}
	}
}