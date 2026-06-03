using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._4_Builder
{
	public class EmployeeBuilder
	{
		private readonly DetailedEmployee _employee = new DetailedEmployee();

		public EmployeeBuilder WithName(string name) { _employee.Name = name; return this; }
		public EmployeeBuilder WithIncome(double income) { _employee.Income = income; return this; }
		public EmployeeBuilder WithInsurance(string insurance) { _employee.Insurance = insurance; return this; }
		public EmployeeBuilder WithMaritalStatus(string status) { _employee.MaritalStatus = status; return this; }
		public EmployeeBuilder WithLocation(string location) { _employee.Location = location; return this; }

		public DetailedEmployee Build() => _employee;
	}
}
