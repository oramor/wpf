using System.Windows;

namespace App_RoutedEvents
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

        public void InitShutdownHandler(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
