using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SimplestThing
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<IPet>()
                .ImplementedBy<Dog>().Named("dog"));
            
            container.Register(Component.For<IPet>()
                .ImplementedBy<Cat>().Named("cat"));

            var defaultPet = container.Resolve<IPet>();
            var cat = container.Resolve<IPet>("cat");
            var dog = container.Resolve<IPet>("dog");

            var allPets = container.ResolveAll<IPet>();

            Console.WriteLine("Default IPet says " + defaultPet.Speak());

            Console.WriteLine("IPet named [cat] says " + cat.Speak());
            Console.WriteLine("IPet named [dog] says " + dog.Speak());

            Console.ReadKey();
        }

        public interface IPet
        {
            string Speak();
        }

        public class Dog : IPet
        {
            public string Speak()
            {
                return "Woof";
            }
        }

        public class Cat : IPet
        {
            public string Speak()
            {
                return "Meow";
            }
        }
    }
}
