using System.Windows;
using System.Windows.Controls;

namespace App_RoutedEvents.Controls
{
    /// <summary>
    /// Interaction logic for TitleBarButtonsArea.xaml
    /// </summary>
    public partial class TitleBarButtonsArea : UserControl
    {
        public TitleBarButtonsArea()
        {
            InitializeComponent();
            shutdownButton.Click += ShutdownButton_Click;
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            e.RoutedEvent = InitShutdownEvent;
            RaiseEvent(e);
        }

        public static readonly RoutedEvent? InitShutdownEvent = EventManager.RegisterRoutedEvent("InitShutdown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ShutdownButton));

        public event RoutedEventHandler InitShutdown
        {
            add => AddHandler(InitShutdownEvent, value);
            remove => RemoveHandler(InitShutdownEvent, value);
        }
    }
}
