using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingDataintoaTask
{
	public class DataImporter
	{
		public void Import(string directory)
		{
			// Import files from this.directory
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var importer = new DataImporter();
			string importDirectory = @"C:\data";
			Task.Factory.StartNew(() => importer.Import(importDirectory));
		}
	}
}
