using System;
using System.Linq;
using StructureMap;

namespace OpenGenericsExample2
{
	public class Program
	{
		readonly IRepository<Fruit> _fruitRepository;
		static Container _container;

		public Program(IRepository<Fruit> fruitRepository)
		{
			_fruitRepository = fruitRepository;
		}

		static void Main(string[] args)
		{
			ConfigureContainer();
			_container.GetInstance<Program>().Run();
		}

		static void ConfigureContainer()
		{
			_container = new Container();
			_container.Configure(x => x.AddRegistry<ApplicationRegistry>());
		}

		void Run()
		{
			Console.WriteLine("Fruits\n______");
			_fruitRepository.GetAll().ToList().ForEach(Console.WriteLine);

			Console.ReadLine();
		}
	}
}