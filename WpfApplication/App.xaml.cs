using System.Windows;
using Autofac;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            this.MainWindow = bootstrapper.Container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }
    }
}
