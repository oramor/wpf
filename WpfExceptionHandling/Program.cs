using System.Windows;

namespace WpfExceptionHandling
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;

            var vm = new MainVM();

            //throw new Exception("This Exception occured in the compostion root.");

            var window = new MainWindow() { DataContext = vm };
            var app = new App();

            App.Current.DispatcherUnhandledException += Application_DispatcherUnhandledException;

            app.Run(window);
        }

        private static void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Application_DispatcherUnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);

            // В этом случае исключение не попадет в AppDomain_UnhandledException
            e.Handled = true;
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is not Exception exception)
                return;

            MessageBox.Show(exception.Message, "AppDomain_UnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
