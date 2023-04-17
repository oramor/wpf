using System.Windows;
using System.Windows.Controls;

namespace TestLibControls
{
    public class XamlIconButton : Button
    {
        static XamlIconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(XamlIconButton),
                new FrameworkPropertyMetadata(typeof(XamlIconButton))
            );
        }
    }
}
