using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._2_FactoryMethod
{
	public static class EmployeeFactory
	{
		public static Employee CreateEmployee(string type, string name, double income)
		{
			return type.ToLower() switch
			{
				"officeemployee" => new OfficeEmployee(name, income),
				"freelancer" => new Freelancer(name, income),
				_ => throw new ArgumentException("Loại nhân viên không hợp lệ")
			};
		}
	}
}
