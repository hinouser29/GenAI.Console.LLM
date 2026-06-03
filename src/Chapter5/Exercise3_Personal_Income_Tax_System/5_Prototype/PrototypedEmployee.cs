using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._5_Prototype
{
	public class PrototypedEmployee : ICloneable
	{
		public string Name { get; set; }
		public double Income { get; set; }
		public string Department { get; set; }

		public PrototypedEmployee(string name, double income, string dept)
		{
			Name = name;
			Income = income;
			Department = dept;
		}

		public object Clone()
		{
			return new PrototypedEmployee(this.Name, this.Income, this.Department);
    }
	}
}
