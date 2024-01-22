using Microsoft.Extensions.Configuration;
using System.Windows;

namespace AppWithConfiguration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App(Microsoft.Extensions.Configuration.IConfiguration config) : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var title = config["MainWindowTitle"] ?? "Title not found";
            var windowWidth = config["WindowSize:Width"];
            var t = config.GetChildren();
            IConfigurationSection tt = config.GetSection("WindowSize");
            var height = tt.GetWindowHeight();
            mainWindow.Title = title;
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
