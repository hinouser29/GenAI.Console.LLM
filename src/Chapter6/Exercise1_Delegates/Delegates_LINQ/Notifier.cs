using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_Delegates.Delegates_LINQ
{
	public class Notifier
	{
		public event Action OnNotify;

		public void Trigger()
		{
			if (OnNotify != null)
			{
				OnNotify();
			}
		}
	}
}
