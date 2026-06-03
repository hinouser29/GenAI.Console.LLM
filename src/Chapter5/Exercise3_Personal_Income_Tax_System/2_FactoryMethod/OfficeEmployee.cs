using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._2_FactoryMethod
{
	public class OfficeEmployee : Employee
	{
		public OfficeEmployee(string name, double income) : base(name, income) { }
		public override double CalculateTax() => Income * 0.1;
	}
}
