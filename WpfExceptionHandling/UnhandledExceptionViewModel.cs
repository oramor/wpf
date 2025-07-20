using System.ComponentModel;

namespace WpfExceptionHandling
{
    internal class UnhandledExceptionViewModel : INotifyPropertyChanged
    {
        string _info = string.Empty;

        public string Info
        {
            get => _info;
            set
            {
                _info = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
