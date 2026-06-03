using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._3_AbstractFactory
{
	public class OfficeTaxCalculator : ITaxCalculator
	{
		public double CalculateTax(double income) => income * 0.1;
	}
}
