using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SimpleLifecycle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            
            container.Register(Component.For<IDog>().ImplementedBy<Dog>());
            container.Register(Component.For<IFish>().ImplementedBy<Fish>());

            var dog1 = container.Resolve<IDog>();
            var dog2 = container.Resolve<IDog>();
            Console.WriteLine("Are dog1 and dog2 the same dog? Answer: " + dog1.Equals(dog2));


            var fish1 = container.Resolve<IFish>();
            var fish2 = container.Resolve<IFish>();
            Console.WriteLine("Are fish1 and fish2 the same fish? Answer: " + fish1.Equals(fish2));

            Console.ReadKey();

            // Note: Singleton is the default lifestyle, and will be used if you don't specify a lifestyle explicitly.
        }
    }
    
    public interface IDog
    {
    }

    [Transient]
    public class Dog : IDog
    {
    }

    public interface IFish
    {
    }

    [Singleton]
    public class Fish : IFish
    {
    }

}