using ImperiumGearHUB.Services.HID;
using ImperiumGearHUB.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ImperiumGearHUB
{
    /// <summary>
    /// App.xaml için etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // Servisler
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<IProfileService, ProfileService>();

            // ViewModels
            services.AddSingleton<KeyboardViewModel>();
            services.AddSingleton<MouseViewModel>();
            services.AddSingleton<MainViewModel>();

            // Views
            services.AddSingleton<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetService<MainViewModel>();
            mainWindow.Show();
        }
    }
}

