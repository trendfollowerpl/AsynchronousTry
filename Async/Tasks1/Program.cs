using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks1
{
	class Program
	{
		static void Main(string[] args)
		{
			Task.Factory.StartNew(() => Console.WriteLine("Hello World"));
			Task.Factory.StartNew(() => Console.WriteLine("Longrunning"), TaskCreationOptions.LongRunning);
			Console.ReadLine();
		}
	}
}
