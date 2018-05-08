using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaining_Tasks_Continuations
{
	class Program
	{
		static void Main(string[] args)
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

			

		}
	}
}
