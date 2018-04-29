using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
	class Program
	{
		static void DataImport(IImport import)
		{
			var cts = new CancellationTokenSource();
			
			var ct = cts.Token;

			Task importTask = import.ImportXmlFilesAsync(@"C:\data", ct);
			
			while (!importTask.IsCompleted)
			{
				Console.Write(".");
				if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
				{
					try
					{
						cts.Cancel();
						importTask.Wait();
					}
					catch (AggregateException ex)
					{
						Console.WriteLine(ex.Flatten());
					}
					
				}
				Console.WriteLine(importTask.Status);
				Thread.Sleep(250);
			}
		}
		static void Main(string[] args)
		{
			DataImport(new Import());
			Console.ReadLine();
		}
	}
}
