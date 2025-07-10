using System.Windows.Input;

namespace WpfExceptionHandling
{
    internal class MainVM
    {
        public ICommand ClickCommand { get; set; } = new ClickCmd();

        sealed class ClickCmd : ICommand
        {
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                throw new Exception("This Exception occured in view model command");
            }
        }
    }
}
