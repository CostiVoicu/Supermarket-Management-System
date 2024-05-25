using Supermarket.Core;
using Supermarket.Model;
using Supermarket.Model.BusinessLogicLayer;
using Supermarket.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Supermarket.ViewModel
{
    public class LogInViewModel : Core.ViewModel
    {
        private LogInBLL _loginBll;

        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }
        public LogInViewModel(INavigationService navService)
        {
            _loginBll = new LogInBLL();
            Navigation = navService;
            UsersList = _loginBll.GetAllUsers();
        }

        public ObservableCollection<user> UsersList
        {
            get => _loginBll.UsersList;
            set => _loginBll.UsersList = value;
        }

        private string _logInUsername;
        public string LogInUsername
        {
            get => _logInUsername; 
            set { _logInUsername = value; OnPropertyChanged(); }
        }
        private string _logInPassword;
        public string LogInPassword
        {
            get => _logInPassword;
            set { _logInPassword = value; OnPropertyChanged(); }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get => _isAdmin;
            set { _isAdmin = value; OnPropertyChanged(); }
        }
        private bool _isCashier;
        public bool IsCashier
        {
            get => _isCashier;
            set { _isCashier = value; OnPropertyChanged(); }
        }
        public ObservableCollection<user> UserList
        {
            get => _loginBll.UsersList;
            set => _loginBll.UsersList = value;
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        public void LogInUser()
        {
            var validUser = UsersList.FirstOrDefault(u => u.name == LogInUsername && u.password == LogInPassword);
            if (validUser == null) 
            {
                MessageBox.Show("Username, password or category are wrong!");
                return; 
            }
            if (!_isAdmin && !_isCashier)
            {
                MessageBox.Show("You must select a category!");
            }
            if (_isAdmin && validUser.user_type_id == 1)
            {
                Navigation.NavigateTo<AdminViewModel>();
            }
            else if (_isCashier && validUser.user_type_id == 2)
            {
                _navigation.NavigateTo<CashierViewModel>(validUser.id);
            }
        }

        private ICommand _logInCommand;
        public ICommand LogInCommand
        {
            get
            {
                if (_logInCommand == null)
                {
                    _logInCommand = new RelayCommand(o => { LogInUser(); }, o => true);
                }
                return _logInCommand;
            }
        }
    }
}
