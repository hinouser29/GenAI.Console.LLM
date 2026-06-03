using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._2_FactoryMethod
{
	public abstract class Employee
	{
		public string Name { get; set; }
		public double Income { get; set; }
		protected Employee(string name, double income) { Name = name; Income = income; }
		public abstract double CalculateTax();
	}
}
