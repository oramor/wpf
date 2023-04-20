using System.Windows.Media;

namespace App_Bindings
{
    public class TestContext
    {
        public TestContext()
        {
            SomeColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        public SolidColorBrush SomeColor { get; }
    }
}
