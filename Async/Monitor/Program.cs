using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonitorMS
{
	public class SmallBusiness
	{
		private decimal cash;
		private decimal receivables;
		private readonly object stateGuard = new { };

		public SmallBusiness(decimal cash, decimal receivables)
		{
			this.cash = cash;
			this.receivables = receivables;
		}
		public void ReceivePayment(decimal amount)
		{
			bool lockTaken = false;

			try
			{
				Monitor.Enter(stateGuard, ref lockTaken);
				cash += amount;
				receivables -= amount;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(stateGuard);
				}
			}
		}

		public void ReceivePayment_LockVersion(decimal amount)
		{
			lock (stateGuard)
			{
				cash += amount;
				receivables -= amount;
			}
		}
		
		public decimal NetWorth
		{
			get
			{
				Monitor.Enter(stateGuard);
				decimal netWorth = cash + receivables;
				Monitor.Exit(stateGuard);
				return netWorth;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
