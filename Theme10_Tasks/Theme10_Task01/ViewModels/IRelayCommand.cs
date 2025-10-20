using System;
using System.Windows.Input;

namespace Theme10_Task01.ViewModels
{
    public interface IRelayCommand : ICommand
    {
        new void Execute(object parameter);
        new bool CanExecute(object parameter);

        new event EventHandler CanExecuteChanged;
    }
}