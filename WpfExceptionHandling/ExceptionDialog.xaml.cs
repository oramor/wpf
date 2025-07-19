using System.Windows;

namespace WpfExceptionHandling
{
    /// <summary>
    /// Interaction logic for ExceptionDialog.xaml
    /// </summary>
    public partial class ExceptionDialog : Window
    {
        public ExceptionDialog() => InitializeComponent();

        public static void ShowDialog(Exception ex)
        {
            var vm = new ExceptionViewModel { Exception = ex };

            var dialog = new ExceptionDialog
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = vm,
            };

            dialog.Show();
        }

        void OkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
