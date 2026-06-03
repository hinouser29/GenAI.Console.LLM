using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise3_Personal_Income_Tax_System._3_AbstractFactory;

namespace Exercise3_Personal_Income_Tax_System._3_AbstractFactory
{
	public interface ITaxCalculator
	{
		double CalculateTax(double income);
	}
	public class GenericEmployee
	{
		public string Name { get; set; }
		public double Income { get; set; }
		public GenericEmployee(string name, double income) { Name = name; Income = income; }
	}
}
