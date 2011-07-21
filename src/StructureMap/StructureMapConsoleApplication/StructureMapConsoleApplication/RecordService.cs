using System.Collections.Generic;

namespace StructureMapConsoleApplication
{
	public class RecordService : IRecordService
	{
		public IEnumerable<string> GetRecords()
		{
			return new[] {"record 1", "record 2", "record 3"};
		}
	}
}