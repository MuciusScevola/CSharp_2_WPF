using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Theme10_Task01.Models;

namespace Theme10_Task01.ViewModels
{
        public class LoginViewModel : INotifyPropertyChanged
        {
            private string _username;
            private string _password;
            private string _statusMessage;
            private bool _isSuccess;

            public string Username
            {
                get => _username;
                set
                {
                    _username = value;
                    OnPropertyChanged();
                    ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }

            public string Password
            {
                get => _password;
                set
                {
                    _password = value;
                    OnPropertyChanged();
                    ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }

            public string StatusMessage
            {
                get => _statusMessage;
                set
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }

            public bool IsSuccess
            {
                get => _isSuccess;
                set
                {
                    _isSuccess = value;
                    OnPropertyChanged();
                }
            }

            public ICommand LoginCommand { get; }

            public LoginViewModel()
            {
                LoginCommand = new RelayCommand(OnLogin, CanLogin);
                StatusMessage = "Введите учетные данные";
                IsSuccess = false;
            }

            private bool CanLogin(object obj) =>
                !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

            private void OnLogin(object obj)
            {
                var isAuthenticated = AuthModel.Authenticate(Username, Password);

                if (isAuthenticated)
                {
                    StatusMessage = "Успешный вход! Добро пожаловать!";
                    IsSuccess = true;
                }
                else
                {
                    StatusMessage = "Неверный логин или пароль";
                    IsSuccess = false;
                }

            LoginCommand.RaiseCanExecutedChanged();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }