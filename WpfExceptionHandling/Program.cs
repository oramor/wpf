﻿using System.Windows;
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

            var vm = new MainVM();

            //throw new Exception("This Exception occured in the compostion root.");

            var window = new MainWindow() { DataContext = vm };

            var app = new App();
            app.DispatcherUnhandledException += Application_DispatcherUnhandledException;
            app.Run(window);
        }

        private static void Dispatcher_UnhandledException1(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            /// Пока что просто логируем, что исключение произошло в контексте UI-фреймворка.
            /// e.Handled остается в значении false. Далее исключение будет обрабатываться
            /// подпиской на уровне домена приложения.

            //MessageBox.Show(e.Exception.Message, "Application_DispatcherUnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);

            // В этом случае исключение не попадет в AppDomain_UnhandledException
            //e.Handled = true;
        }

        static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is not Exception ex)
                return;

            if (UnhandledExceptionDialog.ShowDialog(ex) == true)
            {
                // Вызов условный, т.к. исключение может возникнуть до того, как было создано приложение.
                Application.Current?.Shutdown();
            }

            // MessageBox.Show(exception.Message, "AppDomain_UnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        static void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Dispatcher_UnhandledException", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
