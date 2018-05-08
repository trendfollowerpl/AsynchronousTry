using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaining_Tasks_Continuations
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Task<int> firstTask =
				Task.Factory.StartNew<int>(
					() =>
					{
						Console.WriteLine("First Task");
						return 42;
					});
			Task secondTask =
				firstTask.ContinueWith(
					ftask => Console.WriteLine($"Second Task, First task returned {ftask.Result}")
					);
			await secondTask;

			Console.WriteLine($"firstTask Status: {firstTask.Status}");
			Console.WriteLine($"secondTask Status: {secondTask.Status}");
			Console.ReadLine();

		}
	}
}
