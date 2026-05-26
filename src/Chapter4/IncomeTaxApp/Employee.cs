using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxApp
{
	public class Employee
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public double Income { get; set; }

		public int Dependents { get; set; }

		// Tính thu nhập chịu thuế
		public double GetTaxableIncome()
		{
			double taxableIncome =
				Income - 11000000 - Dependents * 4400000;

			return taxableIncome > 0 ? taxableIncome : 0;
		}

		// Tính PIT
		public double CalculatePIT()
		{
			double taxableIncome = GetTaxableIncome();

			double taxRate;

			if (taxableIncome <= 5000000)
			{
				taxRate = 0.05;
			}
			else if (taxableIncome <= 10000000)
			{
				taxRate = 0.10;
			}
			else if (taxableIncome <= 18000000)
			{
				taxRate = 0.15;
			}
			else
			{
				taxRate = 0.20;
			}

			return taxableIncome * taxRate;
		}

		public override string ToString()
		{
			return $"ID: {Id} - Name: {Name} - " +
				   $"Income: {Income:N0} - " +
				   $"Dependents: {Dependents} - " +
				   $"Tax: {CalculatePIT():N0}";
		}
	}
}
