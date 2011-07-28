using System;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DelgateFactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<IBaker>().ImplementedBy<Baker>());
            container.Register(Component.For<ICake>().ImplementedBy<Cake>().LifeStyle.Transient);

            var baker = container.Resolve<IBaker>();

            Console.WriteLine(baker.BakeCake());
            Console.WriteLine(baker.BakeCake());
            Console.WriteLine(baker.BakeCake());

            Console.ReadKey();
        }
    }

    public interface IBaker
    {
        ICake BakeCake();
    }

    public class Baker : IBaker
    {
        private readonly Func<ICake> _cakeMaker;

        public Baker(Func<ICake> cakeMaker)
        {
            _cakeMaker = cakeMaker;
        }

        public ICake BakeCake()
        {
            return _cakeMaker();
        }
    }

    public class Cake : ICake
    {
        public override string ToString()
        {
            return String.Format("Delicious Cake (serial# {0})", this.GetHashCode());
        }
    }

    public interface ICake
    {
    }
}
