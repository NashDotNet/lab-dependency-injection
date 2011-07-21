using System;
using StructureMap;

namespace StructureMapConsoleApplication
{
	public class Bootstrapper
	{
		IContainer _container;

		public void Run<T>(Action<T> action)
		{
			ConfigureContainer();
			action(_container.GetInstance<T>());
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
	}
}