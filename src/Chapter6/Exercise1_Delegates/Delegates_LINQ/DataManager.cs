using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_Delegates.Delegates_LINQ
{
	public class DataManager
	{
		public event Action<List<int>> OnLargeQuery;

		public List<int> Data { get; set; } = new List<int>();

		public void Add(int x) => Data.Add(x);

		public List<int> Filter(Func<int, bool> rule)
		{
			var result = Data.Where(rule).ToList();

			if (result.Count > 3)
			{
				OnLargeQuery?.Invoke(result);
			}

			return result;
		}
	}
}
