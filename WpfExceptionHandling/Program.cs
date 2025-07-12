using System.Windows;
using System.Windows.Threading;

namespace WpfExceptionHandling
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            //MessageBox.Show("Приложение будет запущено после закрытия этого окна", "Application_DispatcherUnhandledException", MessageBoxButton.OK, MessageBoxImage.Information);

            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSheduler_UnobservedTaskException;

            var vm = new MainVM();

            //throw new Exception("This Exception occured in the compostion root.");

            var window = new MainWindow() { DataContext = vm };
            var app = new App();

            App.Current.DispatcherUnhandledException += Application_DispatcherUnhandledException;

            app.Run(window);
        }

        private static void Dispatcher_UnhandledException1(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // Здесь только логируем ошибку

            MessageBox.Show(e.Exception.Message, "Application_DispatcherUnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);

            // В этом случае исключение не попадет в AppDomain_UnhandledException
            //e.Handled = true;
        }

        static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is not Exception exception)
                return;

            MessageBox.Show(exception.Message, "AppDomain_UnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);

            // Вызов условный, т.к. исключение может возникнуть до того, как было создано приложение.
            Application.Current?.Shutdown();
        }

        static void TaskSheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "TaskSheduler_UnobservedTaskException", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        static void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Dispatcher_UnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
