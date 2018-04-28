using System;
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

		private static Task<string> BetterDownloadWebPageAsync(string url)
		{
			WebRequest request = WebRequest.Create(url);
			IAsyncResult ar = request.BeginGetResponse(null, null);
			Task<string> downloadTask = Task.Factory
				.FromAsync(
				ar,
				iar =>
					{
						using (var response = request.EndGetResponse(iar))
						{
							using (var reader = new StreamReader(response.GetResponseStream()))
							{
								return reader.ReadToEnd();
							}
						}
					});
			return downloadTask;
		}

		private static async Task<string> DownloadTPL(string url)
		{
			WebRequest request = WebRequest.Create(url);
			var response = await request.GetResponseAsync();

			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}

		static async Task Main(string[] args)
		{
			//var t = DownloadWebPageAsync("http://stooq.pl");
			//var t2 = BetterDownloadWebPageAsync("http://stooq.pl");
			var t3 = DownloadTPL("http://stooq.pl");

			progressBar(t3,'.');
			Console.ReadLine();
		}

		private static void progressBar(Task t, char barIndicator)
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
					Console.Write(barIndicator);
					x.Reset();
				}
			}
		}
	}
}
