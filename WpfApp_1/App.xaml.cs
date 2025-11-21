using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp_1.Services;

namespace WpfApp_1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; private set; }
        public App()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddDbContext<Model.AppDbContext>();
            Services = services.BuildServiceProvider();
        }
    }

}
