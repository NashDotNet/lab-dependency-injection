using System;
using System.Linq;

namespace StructureMapConsoleApplication
{
	class Program
	{
		readonly IRecordService _recordService;

		public Program(IRecordService recordService)
		{
			_recordService = recordService;
		}

		static void Main(string[] args)
		{
			new Bootstrapper().Run<Program>(p => p.ShowRecords());
			PromptToExit();
		}

		static void PromptToExit()
		{
			Console.WriteLine("press any key to exit");
			Console.ReadLine();
		}

		void ShowRecords()
		{
			_recordService.GetRecords().ToList().ForEach(Console.WriteLine);
		}
	}
}