using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_Personal_Income_Tax_System._4_Builder
{
	public class DetailedEmployee
	{
		public string Name { get; set; }
		public double Income { get; set; }
		public string Insurance { get; set; }
		public string MaritalStatus { get; set; }
		public string Location { get; set; }

		public override string ToString() =>
			$"Name: {Name}, Income: {Income:N0}, Insurance: {Insurance}, Marital: {MaritalStatus}, Location: {Location}";
	}
}
