using System.Collections.Generic;

namespace StructureMapConsoleApplication
{
	public interface IRecordService
	{
		IEnumerable<string> GetRecords();
	}
}