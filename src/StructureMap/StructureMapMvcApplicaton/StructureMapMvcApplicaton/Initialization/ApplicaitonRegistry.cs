using StructureMap.Configuration.DSL;

namespace StructureMapMvcApplicaton.Initialization
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