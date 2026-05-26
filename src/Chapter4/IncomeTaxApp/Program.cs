namespace IncomeTaxApp
{
	class Program
	{
		static void PrintAll<T>(List<T> items)
		{
			foreach (T item in items)
			{
				Console.WriteLine(item);
			}
		}

		static void Main(string[] args)
		{
			List<Employee> employees = new List<Employee>();

			employees.Add(new Employee
			{
				Id = 1,
				Name = "Alice",
				Income = 15000000,
				Dependents = 1
			});

			employees.Add(new Employee
			{
				Id = 2,
				Name = "Bob",
				Income = 20000000,
				Dependents = 0
			});

			employees.Add(new Employee
			{
				Id = 3,
				Name = "Charlie",
				Income = 35000000,
				Dependents = 2
			});

			employees.Add(new Employee
			{
				Id = 4,
				Name = "David",
				Income = 12000000,
				Dependents = 1
			});

			Console.WriteLine("===== EMPLOYEE LIST =====");

			PrintAll(employees);

			Dictionary<int, Employee> employeeDictionary =
				new Dictionary<int, Employee>();

			foreach (Employee emp in employees)
			{
				employeeDictionary[emp.Id] = emp;
			}

			Console.WriteLine("\n===== FIND EMPLOYEE BY ID =====");

			int searchId = 2;

			if (employeeDictionary.ContainsKey(searchId))
			{
				Console.WriteLine(employeeDictionary[searchId]);
			}

			employees.Sort(new EmployeeIncomeComparer());

			Console.WriteLine("\n===== SORT BY INCOME DESC =====");

			PrintAll(employees);

			Predicate<Employee> highTaxPredicate =
				emp => emp.CalculatePIT() > 1000000;

			List<Employee> highTaxEmployees =
				employees.FindAll(highTaxPredicate);

			Console.WriteLine("\n===== FILTERED (Tax > 1M) =====");

			foreach (Employee emp in highTaxEmployees)
			{
				Console.WriteLine(emp.Name);
			}
		}
	}
}
