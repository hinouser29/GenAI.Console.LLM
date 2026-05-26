using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxApp
{
	public class EmployeeIncomeComparer : IComparer<Employee>
	{
		public int Compare(Employee x, Employee y)
		{
			return y.Income.CompareTo(x.Income);
		}
	}
}
