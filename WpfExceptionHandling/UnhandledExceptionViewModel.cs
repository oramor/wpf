using System.ComponentModel;
using System.Windows.Input;

namespace WpfExceptionHandling
{
    internal class UnhandledExceptionViewModel : INotifyPropertyChanged
    {
        string _details = string.Empty;
        bool _isDetailsCollapsed = true;

        public UnhandledExceptionViewModel()
        {
            DetailsButtonClickCommand = new DetailsButtonClickCmd(this);
        }

        public string Details
        {
            get => _details;
            set
            {
                _details = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Details)));
            }
        }

        public bool IsDetailsCollapsed
        {
            get => _isDetailsCollapsed;
            set
            {
                _isDetailsCollapsed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDetailsCollapsed)));
            }
        }

        public ICommand DetailsButtonClickCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        sealed class DetailsButtonClickCmd(UnhandledExceptionViewModel ctx) : ICommand
        {
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                ctx.IsDetailsCollapsed = !ctx.IsDetailsCollapsed;
            }
        }
    }
}
