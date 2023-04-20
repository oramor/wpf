using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestApp_VSM
{
    class CustomButton : Button
    {
        readonly static Color _defaultColor = Color.FromArgb(255, 0, 255, 0);

        static CustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomButton), new FrameworkPropertyMetadata(typeof(CustomButton)));
        }

        //public CustomButton()
        //{
        //    var color = Color.FromArgb(255, 255, 255, 0);
        //    BackgroundMouseOver = new SolidColorBrush(color);
        //}

        #region BackgroundMouseOver

        public SolidColorBrush BackgroundMouseOver
        {
            get => (SolidColorBrush)GetValue(BackgroundMouseOverProperty);
            set => SetValue(BackgroundMouseOverProperty, value);
        }

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(SolidColorBrush),
            typeof(CustomButton),
            new PropertyMetadata(new SolidColorBrush(_defaultColor))
          );

        #endregion
    }
}
