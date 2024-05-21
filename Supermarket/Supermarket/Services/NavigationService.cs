using Supermarket.Core;
using Supermarket.Model;
using System;
using System.Linq;

namespace Supermarket.Services
{
    public interface INavigationService
    {
        Core.ViewModel CurrentView { get; }

        void NavigateTo<T>() where T : Core.ViewModel;
        void NavigateTo<T>(int userId) where T : Core.ViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        private Core.ViewModel _currentView;
        private Func<Type, Core.ViewModel> _viewModelFactory;
        public Core.ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, Core.ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : Core.ViewModel
        {
            CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
        }
        public void NavigateTo<TViewModel>(int userId) where TViewModel : Core.ViewModel
        {
            CurrentView = CreateViewModel<TViewModel>(userId);
        }
        private Core.ViewModel CreateViewModel<TViewModel>(int userId) where TViewModel : Core.ViewModel
        {
            var viewModelType = typeof(TViewModel);
            var constructors = viewModelType.GetConstructors();

            foreach (var ctor in constructors)
            {
                var parameters = ctor.GetParameters();
                Console.WriteLine($"{ctor.Name} with parameters: {string.Join(", ", parameters.Select(p => p.ParameterType.Name))}");
            }

            var constructor = viewModelType.GetConstructor(new[] { typeof(int) });

            if (constructor == null)
            {
                throw new InvalidOperationException($"No constructor found in {viewModelType.Name} that accepts a single int parameter.");
            }

            return (Core.ViewModel)constructor.Invoke(new object[] { userId });
        }
    }
}
