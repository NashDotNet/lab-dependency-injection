using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutomaticRegistration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new ViewModelInstaller());

            var shell = container.Resolve<IShellViewModel>();

            Console.WriteLine(shell.ToString());

            Console.ReadKey();
        }
    }

    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                                   .Where(x => x.Name.EndsWith("ViewModel"))
                                   .WithService.FirstInterface()
                                   .Configure(c => c.LifeStyle.Transient)
                );
        }
    }

    public interface IShellViewModel
    {
        IDepartmentsViewModel Departments { get; }
        IEmployeesViewModel Employees { get; }
    }

    public interface IDepartmentsViewModel
    {
    }

    public interface IEmployeesViewModel
    {
        IEmployeeOfTheMonthViewModel EmployeeOfTheMonth { get; }
    }

    public interface IEmployeeOfTheMonthViewModel
    {
    }

    public class ShellViewModel : IShellViewModel
    {
        private readonly IDepartmentsViewModel _departments;
        private readonly IEmployeesViewModel _employees;

        public ShellViewModel()
        {
        }

        public ShellViewModel(IDepartmentsViewModel departments, IEmployeesViewModel employees)
        {
            _departments = departments;
            _employees = employees;
        }

        public IDepartmentsViewModel Departments
        {
            get { return _departments; }
        }

        public IEmployeesViewModel Employees
        {
            get { return _employees; }
        }

        public override string ToString()
        {
            return String.Format("ShellViewModel({0}, {1})", Departments, Employees);
        }
    }

    public class DepartmentsViewModel : IDepartmentsViewModel
    {
        public override string ToString()
        {
            return "DepartmentsViewModel()";
        }
    }

    public class EmployeesViewModel : IEmployeesViewModel
    {
        private readonly IEmployeeOfTheMonthViewModel _employeeOfTheMonth;

        public EmployeesViewModel()
        {
        }

        public EmployeesViewModel(IEmployeeOfTheMonthViewModel employeeOfTheMonth)
        {
            _employeeOfTheMonth = employeeOfTheMonth;
        }

        public IEmployeeOfTheMonthViewModel EmployeeOfTheMonth
        {
            get { return _employeeOfTheMonth; }
        }

        public override string ToString()
        {
            return String.Format("EmployeesViewModel({0})", EmployeeOfTheMonth);
        }
    }

    public class EmployeeOfTheMonthViewModel : IEmployeeOfTheMonthViewModel
    {
        public override string ToString()
        {
            return "EmployeeOfTheMonthViewModel";
        }
    }
}