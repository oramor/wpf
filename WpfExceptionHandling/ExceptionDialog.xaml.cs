using System.Windows;

namespace WpfExceptionHandling
{
    /// <summary>
    /// Interaction logic for ExceptionDialog.xaml
    /// </summary>
    public partial class ExceptionDialog : Window
    {
        public ExceptionDialog() => InitializeComponent();

        public static bool? ShowDialog(Exception ex)
        {
            string info = $"\nMessage ---\n{ex.Message}";
            info += $"\nHelpLink ---\n{ex.HelpLink}";
            info += $"\nSource ---\n{ex.Source}";
            info += $"\nStackTrace ---\n{ex.StackTrace}";
            info += $"\nTargetSite ---\n{ex.TargetSite}";

            var vm = new UnhandledExceptionViewModel { Info = info };

            var dialog = new ExceptionDialog
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = vm,
            };

            return dialog.ShowDialog();
        }

        void OkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
