using System;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace CastleWithXmlAndCodeRegistration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Note: look at app.config and see what IMenu registrations are being wired up there.

            // Our strategy here is to set the defaults in code, and let config override them.
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

            container.Register(Component.For<IWaiter>().ImplementedBy<Waiter>().Named("waiter"));
            container.Register(Component.For<IMenu>().ImplementedBy<LunchMenu>().Named("menu"));

            var waiter = container.Resolve<IWaiter>();

            Console.WriteLine(waiter.AnnounceTheSpecials());
            Console.ReadKey();
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