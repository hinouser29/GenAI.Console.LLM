using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._3_AbstractFactory
{
	public interface IEmployeeFactory
	{
		GenericEmployee CreateEmployee(string name, double income);
		ITaxCalculator CreateTaxCalculator();
	}
}
