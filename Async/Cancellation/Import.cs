using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
	class Import : IImport
	{
		public void ImportXmlFiles(string dataDirectory)
		{
			throw new NotImplementedException();
		}

		public Task ImportXmlFilesAsync(string dataDirectory)
		{
			return ImportXmlFilesAsync(dataDirectory, CancellationToken.None);
		}

		public Task ImportXmlFilesAsync(string dataDirectory, CancellationToken ct)
		{
			//ct.ThrowIfCancellationRequested();
			if (ct.IsCancellationRequested) throw new OperationCanceledException("Cancelled", ct);
			return Task.Delay(TimeSpan.FromMinutes(2), ct);
		}
	}
}
