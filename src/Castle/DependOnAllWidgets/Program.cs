using System;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DependOnAllWidgets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));

            container.Register(AllTypes.FromThisAssembly()
                                   .Where(typeof (IWidget).IsAssignableFrom)
                                   .Configure(c => c.LifeStyle.Transient));
            container.Register(Component
                                   .For<IMachine>()
                                   .ImplementedBy<Machine>()
                                   .LifeStyle.Transient);

            var x = container.Resolve<IMachine>();

            Console.WriteLine("Widgets loaded into Machine: {0}", x.WidgetCount);
        }
    }

    public interface IMachine
    {
        int WidgetCount { get; }
    }

    public interface IWidget
    {
    }

    public class HydraulicWidget : IWidget
    {
    }

    public class PneumaticWidget : IWidget
    {
    }

    public class ElectricWidget : IWidget
    {
    }

    public class SpringLoadedWidget : IWidget
    {
    }

    public class Machine : IMachine
    {
        private readonly IWidget[] _widgets;

        public Machine(IWidget[] widgets)
        {
            _widgets = widgets;
        }

        #region IMachine Members

        public int WidgetCount
        {
            get { return _widgets.Length; }
        }

        #endregion
    }

    public class ArrayResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;

        public ArrayResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        #region ISubDependencyResolver Members

        public object Resolve(CreationContext context, ISubDependencyResolver parentResolver,
                              ComponentModel model,
                              DependencyModel dependency)
        {
            return kernel.ResolveAll(dependency.TargetType.GetElementType(), null);
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver parentResolver,
                               ComponentModel model,
                               DependencyModel dependency)
        {
            return dependency.TargetType != null &&
                   dependency.TargetType.IsArray &&
                   dependency.TargetType.GetElementType().IsInterface;
        }

        #endregion
    }
}