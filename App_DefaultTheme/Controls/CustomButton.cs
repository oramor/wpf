using System.Windows;
using System.Windows.Controls;

namespace App_DefaultTheme.Controls
{
    public class CustomButton : Control
    {
        static CustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomButton), new FrameworkPropertyMetadata(typeof(CustomButton)));
        }
    }
}
