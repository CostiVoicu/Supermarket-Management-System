using Supermarket.Core;
using Supermarket.Model;
using Supermarket.Model.BusinessLogicLayer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModel
{
    public class AdminViewModel : Core.ViewModel
    {
        private AdminBLL _adminBll;
        public AdminViewModel()
        {
            _adminBll = new AdminBLL();
            UsersList = _adminBll.GetAllUsers();
            ProductsList = _adminBll.GetAllProducts();
            ProducersList = _adminBll.GetAllProducers();
            ProductStocksList = _adminBll.GetAllProductStocks();
            CategoriesList = _adminBll.GetAllCategories();

            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;
        }
        public ObservableCollection<select_user_Result> UsersList
        {
            get => _adminBll.UsersList;
            set => _adminBll.UsersList = value;
        }
        public ObservableCollection<product> ProductsList
        {
            get => _adminBll.ProductsList;
            set => _adminBll.ProductsList = value;
        }
        public ObservableCollection<producer> ProducersList
        {
            get => _adminBll.ProducersList;
            set => _adminBll.ProducersList = value;
        }
        public ObservableCollection<product_stock> ProductStocksList
        {
            get => _adminBll.ProductStocksList;
            set => _adminBll.ProductStocksList = value;
        }
        public ObservableCollection<product_categories> CategoriesList
        {
            get => _adminBll.CategoriesList;
            set => _adminBll.CategoriesList = value;
        }
        private Visibility usersDataGridVisibility;
        public Visibility UsersDataGridVisibility
        {
            get { return usersDataGridVisibility; }
            set
            {
                usersDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility productsDataGridVisibility;
        public Visibility ProductsDataGridVisibility
        {
            get { return productsDataGridVisibility; }
            set
            {
                productsDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility producersDataGridVisibility;
        public Visibility ProducersDataGridVisibility
        {
            get { return producersDataGridVisibility; }
            set
            {
                producersDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility stocksDataGridVisibility;
        public Visibility StocksDataGridVisibility
        {
            get { return stocksDataGridVisibility; }
            set
            {
                stocksDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility categoriesDataGridVisibility;
        public Visibility CategoriesDataGridVisibility
        {
            get { return categoriesDataGridVisibility; }
            set
            {
                categoriesDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private void ShowUsersDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Visible;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;
        }
        private void ShowProductsDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Visible;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;
        }
        private void ShowProducersDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Visible;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;
        }
        private void ShowStocksDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Visible;
            CategoriesDataGridVisibility = Visibility.Collapsed;
        }
        private void ShowCategoriesDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Visible;
        }
        private ICommand _showUsersDataGridCommand;
        public ICommand ShowUsersDataGridCommand
        {
            get
            {
                if (_showUsersDataGridCommand == null)
                {
                    _showUsersDataGridCommand = new RelayCommand(ShowUsersDataGrid, o => true);
                }
                return _showUsersDataGridCommand;
            }
        }
        private ICommand _showProductsDataGridCommand;
        public ICommand ShowProductsDataGridCommand
        {
            get
            {
                if (_showProductsDataGridCommand == null)
                {
                    _showProductsDataGridCommand = new RelayCommand(ShowProductsDataGrid, o => true);
                }
                return _showProductsDataGridCommand;
            }
        }
        private ICommand _showProducersDataGridCommand;
        public ICommand ShowProducersDataGridCommand
        {
            get
            {
                if (_showProducersDataGridCommand == null)
                {
                    _showProducersDataGridCommand = new RelayCommand(ShowProducersDataGrid, o => true);
                }
                return _showProducersDataGridCommand;
            }
        }
        private ICommand _showStocksDataGridCommand;
        public ICommand ShowStocksDataGridCommand
        {
            get
            {
                if (_showStocksDataGridCommand == null)
                {
                    _showStocksDataGridCommand = new RelayCommand(ShowStocksDataGrid, o => true);
                }
                return _showStocksDataGridCommand;
            }
        }
        private ICommand _showCategoriesDataGridCommand;
        public ICommand ShowCategoriesDataGridCommand
        {
            get
            {
                if (_showCategoriesDataGridCommand == null)
                {
                    _showCategoriesDataGridCommand = new RelayCommand(ShowCategoriesDataGrid, o => true);
                }
                return _showCategoriesDataGridCommand;
            }
        }
    }
}
