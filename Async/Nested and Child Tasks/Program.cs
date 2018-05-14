using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_and_Child_Tasks
{
	class Program
	{
		static async Task Main(string[] args)
		{   //does not throw error of inner task
			var Task1 = Task.Factory.StartNew(() =>
				Task.Factory.StartNew((() =>
				{
					Console.WriteLine("Nested..");
					throw new Exception("Nested exception Task 1");
				}))
				, TaskCreationOptions.DenyChildAttach);

			//inner error affect outer task
			var Task2 = Task.Factory.StartNew(() =>
				Task.Factory.StartNew(() =>
				{
					Console.WriteLine("Nested..");
					throw new Exception("Nested exception Task 2");
				}, TaskCreationOptions.AttachedToParent));

			await Task1;
			await Task2;


			Console.ReadLine();
		}
	}
}
