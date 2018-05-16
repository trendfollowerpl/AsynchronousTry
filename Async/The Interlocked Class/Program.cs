using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_Interlocked_Class
{
	class Program
	{
		static void Main(string[] args)
		{
			const int iterations = 100000000;
			const int numTasks = 2;
			var tasks = new List<Task>();
			int value = 0;

			Enumerable.Range(0, numTasks).ToList().ForEach(notused =>
			{
				tasks.Add(Task.Factory.StartNew(() =>
				{
					IncrementValue(ref value, iterations);
				}));
			});

			Task.WaitAll(tasks.ToArray());
			Console.WriteLine("Expected value: {0}, Actual value: {1}", numTasks * iterations, value);
			Console.ReadLine();
		}

		private static void IncrementValue(ref int value, int iterations)
		{
			for (int i = 0; i < iterations; i++)
			{
				Interlocked.Increment(ref value);
			}
		}
	}
}
