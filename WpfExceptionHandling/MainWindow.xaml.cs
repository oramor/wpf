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

        private void ButtonBeginInvoke_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(() => { throw new Exception("This Exception occured in the MainWindow begin invoke handler"); });
        }

        private void TaskRunButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => { throw new Exception("This Exception occured in the MainWindow Task.Run() handler"); });
        }
    }
}