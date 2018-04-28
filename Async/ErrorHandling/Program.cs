using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Task task = Task.Factory.StartNew(() => throw new Exception("HAHA"));
			try
			{
				await task;
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
			Console.ReadLine();
		}
	}
}
