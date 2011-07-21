using StructureMap.Configuration.DSL;

namespace OpenGenericsExample2
{
	class ApplicationRegistry : Registry
	{
		public ApplicationRegistry()
		{
			Scan(x =>
				{
					x.TheCallingAssembly();
					x.ConnectImplementationsToTypesClosing(typeof (IRepository<>));
				});
		}
	}
}