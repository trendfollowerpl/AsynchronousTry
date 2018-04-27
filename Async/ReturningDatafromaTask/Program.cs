﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReturningDatafromaTask
{
	class Program
	{
		private static string DownloadWebPage(string url)
		{
			WebRequest request = WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			var reader = new StreamReader(response.GetResponseStream());
			{
				return reader.ReadToEnd();
			}
		}

		private static async Task<string> DownloadWebPageAsync(string url)
		{
			await Task.Delay(2000);
			return await Task.Factory.StartNew<string>(() => DownloadWebPage(url));
		}

		static async Task Main(string[] args)
		{
			var t = DownloadWebPageAsync("http://stooq.pl");
			string download = "dupa";
			progressBar(t);
			Console.ReadLine();
		}

		private static void progressBar(Task t)
		{
			var x = new Stopwatch();
			x.Start();

			while (!t.IsCompleted)
			{
				if (!x.IsRunning)
				{
					x.Start();
				}
				if (x.ElapsedMilliseconds > 50)
				{
					Console.Write('.');
					x.Reset();
				}
			}
		}
	}
}
