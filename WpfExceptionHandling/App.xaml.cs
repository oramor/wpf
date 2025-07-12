using System.Windows;

namespace WpfExceptionHandling
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            TaskScheduler.UnobservedTaskException += TaskSheduler_UnobservedTaskException;
        }

        static void TaskSheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "TaskSheduler_UnobservedTaskException", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
