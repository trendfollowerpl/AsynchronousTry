using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
	public interface IImport
	{
		void ImportXmlFiles(string dataDirectory);
		Task ImportXmlFilesAsync(string dataDirectory);
		Task ImportXmlFilesAsync(string dataDirectory, CancellationToken ct);
	}
}
