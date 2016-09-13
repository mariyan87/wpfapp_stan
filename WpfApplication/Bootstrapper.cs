using System.Reflection;
using Autofac;

namespace WpfApplication
{
    internal class Bootstrapper
    {
        public IContainer Container { get; set; }

        public void Run()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(typeof(Bootstrapper).Assembly)
                            .FindConstructorsWith(t => t.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance));

            this.Container = containerBuilder.Build();
        }
    }
}