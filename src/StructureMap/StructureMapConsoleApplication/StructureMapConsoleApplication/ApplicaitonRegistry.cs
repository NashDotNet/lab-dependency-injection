using StructureMap.Configuration.DSL;

namespace StructureMapConsoleApplication
{
	public class ApplicaitonRegistry : Registry
	{
		public ApplicaitonRegistry()
		{
			Scan(x =>
					{
					x.TheCallingAssembly();
					x.WithDefaultConventions();
				});
		}
	}
}