using Supermarket.Core;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModel
{
    public class MainViewModel : Core.ViewModel
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

        public RelayCommand NavigateStartCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateStartCommand = new RelayCommand(o => { Navigation.NavigateTo<StartViewModel>(); }, o => true);
        }
    }
}
