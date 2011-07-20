using System.Web.Mvc;
using StructureMap;
using StructureMapMvcApplicaton.Infrastructure;

namespace StructureMapMvcApplicaton.Initialization
{
	public class Bootstrapper
	{
		IContainer _container;

		public void Run()
		{
			ConfigureContainer();
			ConfigureServiceLocator();
		}

		void ConfigureContainer()
		{
			// Create container instance and look for StructureMap registries in the calling assembly.
			// StructureMap registries are modules containing specific registration information.
			_container = new Container(c =>
			                           c.Scan(x =>
			                           	{
			                           		x.TheCallingAssembly();
			                           		x.LookForRegistries();
			                           	}));
		}

		void ConfigureServiceLocator()
		{
			// Adaptor between ASP.Net MVC's Service Locator and StructureMap
			DependencyResolver.SetResolver(new StructureMapDependencyResolver(_container));
		}
	}
}