using System;
using System.Windows.Input;

namespace Theme10_Task01.ViewModels
{
    public interface IRelayCommand : ICommand
    {
        void Execute(object parameter);
        bool CanExecute(object parameter);

        event EventHandler CanExecuteChanged;
    }
}
