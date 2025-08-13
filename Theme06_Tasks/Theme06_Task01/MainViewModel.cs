using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextAnalyzer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _textContent = "";
        private bool _showDetails = false;

        public string TextContent
        {
            get => _textContent;
            set
            {
                if (_textContent != value)
                {
                    _textContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowDetails
        {
            get => _showDetails;
            set
            {
                if (_showDetails != value)
                {
                    _showDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}