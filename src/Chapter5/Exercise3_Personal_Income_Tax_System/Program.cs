using System;
using Exercise3_Personal_Income_Tax_System._1_Singleton;
using Exercise3_Personal_Income_Tax_System._2_FactoryMethod;
using Exercise3_Personal_Income_Tax_System._3_AbstractFactory;
using Exercise3_Personal_Income_Tax_System._4_Builder;
using Exercise3_Personal_Income_Tax_System._5_Prototype;

namespace Exercise3_Personal_Income_Tax_System
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// 1. Test Singleton
			Console.WriteLine("=== 1. DEMO SINGLETON PATTERN ===");
			TaxConfig.Instance.GetConfigValues();

			// 2. Test Factory Method
			Console.WriteLine("\n=== 2. DEMO FACTORY METHOD PATTERN ===");
			Employee emp1 = EmployeeFactory.CreateEmployee("OfficeEmployee", "An Nguyễn", 15000000);
			Console.WriteLine($"Nhân viên: {emp1.Name} | Thuế: {emp1.CalculateTax():N0} VND");

			// 3. Test Abstract Factory
			Console.WriteLine("\n=== 3. DEMO ABSTRACT FACTORY PATTERN ===");
			IEmployeeFactory abstractFactory = new FreelancerFactory();
			GenericEmployee genericEmp = abstractFactory.CreateEmployee("Cường Lê", 20000000);
			ITaxCalculator taxCalculator = abstractFactory.CreateTaxCalculator();
			Console.WriteLine($"Family Nhân viên: {genericEmp.Name} | Thuế: {taxCalculator.CalculateTax(genericEmp.Income):N0} VND");

			// 4. Test Builder
			Console.WriteLine("\n=== 4. DEMO BUILDER PATTERN ===");
			DetailedEmployee detailedEmp = new EmployeeBuilder()
												.WithName("Dũng Phạm")
												.WithIncome(25000000)
												.WithLocation("Đà Nẵng")
												.Build();
			Console.WriteLine(detailedEmp.ToString());

			// 5. Test Prototype
			Console.WriteLine("\n=== 5. DEMO PROTOTYPE PATTERN ===");
			PrototypedEmployee templateEmp = new PrototypedEmployee("Mẫu IT", 10000000, "Phòng công nghệ");
			PrototypedEmployee empCloned = (PrototypedEmployee)templateEmp.Clone();
			empCloned.Name = "Hoa Hoàng";
			Console.WriteLine($"Gốc: {templateEmp.Name} -> Bản sao cloned: {empCloned.Name}");

			Console.ReadLine();
		}
	}
}
