using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._3_AbstractFactory
{
	public class OfficeEmployeeFactory : IEmployeeFactory
	{
		public GenericEmployee CreateEmployee(string name, double income) => new GenericEmployee(name, income);
		public ITaxCalculator CreateTaxCalculator() => new OfficeTaxCalculator();
	}
}
