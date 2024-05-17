using Microsoft.Extensions.DependencyInjection;
using Supermarket.Services;
using Supermarket.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(serviceProvider => new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LogInViewModel>();
            services.AddSingleton<AdminViewModel>();
            services.AddSingleton<CashierViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, Core.ViewModel>>(serviceProvider => viewModelType => (Core.ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }
    }
}
