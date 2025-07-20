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
            string info = string.Empty;
            info += string.IsNullOrEmpty(ex.Message) ? "" : $"\nMessage ---\n{ex.Message}";
            info += ex.HelpLink == null ? "" : $"\nHelpLink ---\n{ex.HelpLink}";
            info += ex.Source == null ? "" : $"\nSource ---\n{ex.Source}";
            info += ex.StackTrace == null ? "" : $"\nStackTrace ---\n{ex.StackTrace}";
            info += ex.TargetSite == null ? "" : $"\nTargetSite ---\n{ex.TargetSite}";

            var vm = new UnhandledExceptionViewModel { Info = info };

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
