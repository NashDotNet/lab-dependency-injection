using System;
using System.Linq;
using StructureMap;

namespace OpenGenericsExample2
{
	public class Program
	{
		static Container _container;
		readonly IRepository<Color> _colorRepository;
		readonly IRepository<Pickle> _pickleRepository;

		public Program(IRepository<Color> colorRepository, IRepository<Pickle> pickleRepository)
		{
			_colorRepository = colorRepository;
			_pickleRepository = pickleRepository;
		}

		static void Main(string[] args)
		{
			ConfigureContainer();
			_container.GetInstance<Program>().Run();
		}

		static void ConfigureContainer()
		{
			_container = new Container(c =>
				{
					c.For(typeof (IRepository<>)).Use(typeof (ConcreteRepository<>));
					c.For<IDatabaseContext>().Use(() =>
						{
							// Fake data store
							var context = new DatabaseContext();

							// Kinda like adding records to a Color table
							context.AddItem(new Color("Red"));
							context.AddItem(new Color("Yellow"));
							context.AddItem(new Color("Blue"));

							// Kinda like adding records to a Pickle table
							context.AddItem(new Pickle("Kosher Dill"));
							context.AddItem(new Pickle("Sweet"));
							context.AddItem(new Pickle("Bread and Butter"));

							return context;
						});
				});
		}

		void Run()
		{
			Console.WriteLine("Colors\n_____");
			_colorRepository.GetAll().ToList().ForEach(Console.WriteLine);

			Console.WriteLine("\n\nPickles\n_______");
			_pickleRepository.GetAll().ToList().ForEach(Console.WriteLine);

			Console.ReadLine();
		}
	}
}