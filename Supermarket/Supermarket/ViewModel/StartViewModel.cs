using Supermarket.Core;
using Supermarket.Services;

namespace Supermarket.ViewModel
{
    public class StartViewModel : Core.ViewModel
    {
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

        public RelayCommand NavigateLogInCommand { get; set; }
        public RelayCommand NavigateSignUpCommand { get; set; }

        public StartViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateLogInCommand = new RelayCommand(o => { Navigation.NavigateTo<LogInViewModel>(); }, o => true);
            NavigateSignUpCommand = new RelayCommand(o => { Navigation.NavigateTo<SignUpViewModel>(); }, o => true);
            OnPropertyChanged();
        }
    }
}
