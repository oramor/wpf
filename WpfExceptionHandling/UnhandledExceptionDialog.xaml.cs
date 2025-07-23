using System.Windows;

namespace WpfExceptionHandling
{
    /// <summary>
    /// Interaction logic for ExceptionDialog.xaml
    /// </summary>
    public partial class UnhandledExceptionDialog : Window
    {
        public UnhandledExceptionDialog() => InitializeComponent();

        public static bool? ShowDialog(Exception ex)
        {
            string details = string.Empty;
            details += string.IsNullOrEmpty(ex.Message) ? "" : $"\nMessage ---\n{ex.Message}";
            details += ex.HelpLink == null ? "" : $"\nHelpLink ---\n{ex.HelpLink}";
            details += ex.Source == null ? "" : $"\nSource ---\n{ex.Source}";
            details += ex.StackTrace == null ? "" : $"\nStackTrace ---\n{ex.StackTrace}";
            details += ex.TargetSite == null ? "" : $"\nTargetSite ---\n{ex.TargetSite}";

            var vm = new UnhandledExceptionViewModel { Details = details };

            var dialog = new UnhandledExceptionDialog
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = vm,
            };

            return dialog.ShowDialog();
        }

        void QuitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
