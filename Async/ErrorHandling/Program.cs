using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
	class Program
	{
		static void Main(string[] args)
		{
			Task task = Task.Factory.StartNew(() => throw new Exception("HAHA"));
			try
			{
				task.Wait();
			}
			catch (AggregateException ex)
			{
				Console.Write(ex.Flatten());
			}
			Console.ReadLine();
		}
	}
}
