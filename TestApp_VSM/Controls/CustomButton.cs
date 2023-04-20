using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestApp_VSM
{
    class CustomButton : Button
    {
        readonly static Color _defaultBackgroundMouseOverColor = Color.FromRgb(255, 0, 255);
        readonly static Color _defaultBackgroundNormalColor = Color.FromRgb(255, 255, 255);

        static CustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomButton), new FrameworkPropertyMetadata(typeof(CustomButton)));
        }

        //public CustomButton()
        //{
        //    var color = Color.FromArgb(255, 255, 255, 0);
        //    BackgroundMouseOver = new SolidColorBrush(color);
        //}

        #region BackgroundNormal

        public SolidColorBrush BackgroundNormal
        {
            get => (SolidColorBrush)GetValue(BackgroundNormalProperty);
            set => SetValue(BackgroundNormalProperty, value);
        }

        public static readonly DependencyProperty BackgroundNormalProperty = DependencyProperty.Register(
            nameof(BackgroundNormal),
            typeof(SolidColorBrush),
            typeof(CustomButton),
            new FrameworkPropertyMetadata(new SolidColorBrush(_defaultBackgroundNormalColor) {
                //BindsTwoWayByDefault = true,
            })
          );

        #endregion

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
            new PropertyMetadata(new SolidColorBrush(_defaultBackgroundMouseOverColor))
          );

        #endregion
    }
}
