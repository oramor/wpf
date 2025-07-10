using System.Windows;

namespace WpfExceptionHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception("This Exception occured in the MainWindow event handler");
        }

        private async void AsyncButton_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.InvokeAsync(
                () => { throw new Exception("This Exception occured in the MainWindow event async handler"); }
            );
        }
    }
}