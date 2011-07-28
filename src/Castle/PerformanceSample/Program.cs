using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace PerformanceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticks = DateTime.Now.Ticks;

            Console.WriteLine("Start : {0}", GetTimeElapsedSince(ticks));

            var container = new WindsorContainer();
            Console.WriteLine("Container created : {0}", GetTimeElapsedSince(ticks));

            container.Install(
                new DummyInstaller(),
                new NestedInstaller());

            Console.WriteLine("Types registered [{1}] : {0}", GetTimeElapsedSince(ticks), 1);

            var dummy = container.Resolve<IDummy100Service>();
            Console.WriteLine(dummy);
            Console.WriteLine("Resolved IDummy100Service : {0}", GetTimeElapsedSince(ticks));

            var nested = container.Resolve<INested0Service>();
            Console.WriteLine(nested);
            Console.WriteLine("Resolved INested0Service : {0}", GetTimeElapsedSince(ticks));

            Console.ReadKey();
        }

        private static TimeSpan GetTimeElapsedSince(long previousTicks)
        {
            return new TimeSpan((DateTime.Now.Ticks - previousTicks));
        }
    }

    public class DummyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                                   .Where(x => x.Name.StartsWith("Dummy"))
                                   .WithService.FirstInterface()
                                   .Configure(c => c.LifeStyle.Transient)
                );
        }
    }

    public class NestedInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                                   .Where(x => x.Name.StartsWith("Nested"))
                                   .WithService.FirstInterface()
                                   .Configure(c => c.LifeStyle.Singleton)
                );
        }
    }

    //var sb = new StringBuilder();

    //for(var x = 0; x < 1000; x++)
    //{  
    //    var name = "Nested" + x + "Service";

    //    sb.AppendFormat("public interface I{0} {{}}\r\n", name);
    //    sb.AppendFormat("public class {0} : I{0} {{\r\npublic {0}({1} dep){{}}\r\n}}\r\n", 
    //        name, 
    //        "Nested" + (x+1) + "Service");
    //}

    //Console.WriteLine(sb.ToString());
}
