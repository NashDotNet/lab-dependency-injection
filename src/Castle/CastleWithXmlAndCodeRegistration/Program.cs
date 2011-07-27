using System;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;

namespace CastleWithXmlAndCodeRegistration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Note: look at app.config and see what IMenu registrations are being wired up there.
            
            // In Castle, the default implementation for a service is the first registered implementation.

            //IWindsorContainer container = ConfigureContainerSoThatXmlWins();
            IWindsorContainer container = ConfigureContainerSoThatCodeWins();
            
            var waiter = container.Resolve<IWaiter>();

            Console.WriteLine(waiter.AnnounceTheSpecials());
            Console.ReadKey();
        }

        private static IWindsorContainer ConfigureContainerSoThatCodeWins()
        {
            IWindsorContainer container = new WindsorContainer();

            container.Register(Component.For<IWaiter>().ImplementedBy<Waiter>().Named("waiter"));
            container.Register(Component.For<IMenu>().ImplementedBy<LunchMenu>().Named("menu"));

            container.Install(Configuration.FromXml(new ConfigResource("castle")));
            
            return container;
        }

        private static IWindsorContainer ConfigureContainerSoThatXmlWins()
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

            container.Register(Component.For<IWaiter>().ImplementedBy<Waiter>().Named("waiter"));
            container.Register(Component.For<IMenu>().ImplementedBy<LunchMenu>().Named("menu"));

            return container;
        }
    }

    public interface IMenu
    {
        string TheSpecials { get; }
    }

    public interface IWaiter
    {
        string AnnounceTheSpecials();
    }

    public class Waiter : IWaiter
    {
        private readonly IMenu _menu;

        public Waiter(IMenu menu)
        {
            _menu = menu;
        }

        public string AnnounceTheSpecials()
        {
            return "May I suggest the " + _menu.TheSpecials;
        }
    }

    public class LunchMenu : IMenu
    {
        public string TheSpecials
        {
            get { return "ham and cheese with a frosty root beer"; }
        }
    }

    public class BreakfastMenu : IMenu
    {
        public string TheSpecials
        {
            get { return "bacon and eggs with strong coffee"; }
        }
    }
}