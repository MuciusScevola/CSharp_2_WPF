using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Theme10_Task01.ViewModels
{
    internal interface IRelayCommand : ICommand
    {
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }
}
