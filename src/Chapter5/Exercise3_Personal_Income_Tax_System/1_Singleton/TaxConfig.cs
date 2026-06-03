using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

namespace Exercise3_Personal_Income_Tax_System._1_Singleton
{
	public sealed class TaxConfig
	{
		private static readonly TaxConfig _instance = new TaxConfig();

		public decimal StandardDeduction { get; } = 11000000m;
		public decimal DependentAllowance { get; } = 4400000m;

		private TaxConfig() { }

		public static TaxConfig Instance => _instance;

		public void GetConfigValues()
		{
			Console.WriteLine($"Mức giảm trừ bản thân: {StandardDeduction:N0} VND");
			Console.WriteLine($"Mức giảm trừ người phụ thuộc: {DependentAllowance:N0} VND");
		}
	}
}