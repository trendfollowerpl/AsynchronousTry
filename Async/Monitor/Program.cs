using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
	public class SmallBusiness
	{
		private decimal cash;
		private decimal receivables;
		public SmallBusiness(decimal cash, decimal receivables)
		{
			this.cash = cash;
			this.receivables = receivables;
		}
		public void ReceivePayment(decimal amount)
		{
			cash += amount;
			receivables -= amount;
		}
		public decimal NetWorth
		{
			get { return cash + receivables; }
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
