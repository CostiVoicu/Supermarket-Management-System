using Supermarket.Core;
using Supermarket.Model;
using Supermarket.Model.BusinessLogicLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Supermarket.ViewModel
{
    enum ModeType
    {
        View,
        Add,
        Edit
    }
    public class AdminViewModel : Core.ViewModel
    {
        private AdminBLL _adminBll;
        private ModeType _currentMode;
        private bool _cancel;
        public AdminViewModel()
        {
            _currentMode = ModeType.View;
            _cancel = false;

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

            UsersFormVisibility = Visibility.Collapsed;
            ProductsFormVisibility = Visibility.Collapsed;
            ProducersFormVisibility = Visibility.Collapsed;
            StocksFormVisibility = Visibility.Collapsed;
            CategoriesFormVisibility = Visibility.Collapsed;

            ViewControlsVisibility = Visibility.Visible;
            AddControlsVisibility = Visibility.Hidden;
            EditControlsVisibility = Visibility.Hidden;
            FormsVisibility = Visibility.Hidden;

            CurrentUser = new select_user_Result();
            BackupUser = new select_user_Result();
            CurrentProduct = new select_product_Result();
            CurrentProducer = new select_producer_Result();
            CurrentStock = new select_stock_Result();
            CurrentCategory = new select_category_Result();

            UserTypesComboBox = new List<string>();
            CategoriesComboBox = new List<string>();
            ProducersComboBox = new List<string>();
            CountriesComboBox = new List<string>();
            ProductsComboBox = new List<string>();
            UnitsComboBox = new List<string>();

            UpdateUserTypesComboBox();
            UpdateCountriesComboBox();
            UpdateUnitsComboBox();
            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();
        }
        #region Entities Collections
        public ObservableCollection<select_user_Result> UsersList
        {
            get => _adminBll.UsersList;
            set => _adminBll.UsersList = value;
        }
        public ObservableCollection<select_product_Result> ProductsList
        {
            get => _adminBll.ProductsList;
            set => _adminBll.ProductsList = value;
        }
        public ObservableCollection<select_producer_Result> ProducersList
        {
            get => _adminBll.ProducersList;
            set => _adminBll.ProducersList = value;
        }
        public ObservableCollection<select_stock_Result> ProductStocksList
        {
            get => _adminBll.ProductStocksList;
            set => _adminBll.ProductStocksList = value;
        }
        public ObservableCollection<select_category_Result> CategoriesList
        {
            get => _adminBll.CategoriesList;
            set => _adminBll.CategoriesList = value;
        }
        #endregion

        #region Entities Element
        private select_user_Result _currentUser;
        public select_user_Result CurrentUser
        {
            get { return _currentUser; }
            set 
            {
                _currentUser = value; 
                OnPropertyChanged();
            }
        }
        private select_user_Result _backupUser;
        public select_user_Result BackupUser
        {
            get { return _backupUser; }
            set
            {
                _backupUser = value;
                OnPropertyChanged();
            }
        }
        private select_product_Result _currentProduct;
        public select_product_Result CurrentProduct
        {
            get { return _currentProduct; }
            set 
            { 
                _currentProduct = value;
                OnPropertyChanged();
            }
        }
        private select_producer_Result _currentProducer;
        public select_producer_Result CurrentProducer
        {
            get { return _currentProducer; }
            set 
            { 
                _currentProducer = value; 
                OnPropertyChanged();
            }
        }
        private select_stock_Result _currentStock;
        public select_stock_Result CurrentStock
        {
            get { return _currentStock; }
            set 
            { 
                _currentStock = value;
                OnPropertyChanged();
            }
        }
        private select_category_Result _currentCategory;
        public select_category_Result CurrentCategory
        {
            get { return _currentCategory; }
            set 
            { 
                _currentCategory = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Grid Visibility Variables
        private Visibility _usersDataGridVisibility;
        public Visibility UsersDataGridVisibility
        {
            get { return _usersDataGridVisibility; }
            set
            {
                _usersDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _productsDataGridVisibility;
        public Visibility ProductsDataGridVisibility
        {
            get { return _productsDataGridVisibility; }
            set
            {
                _productsDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _producersDataGridVisibility;
        public Visibility ProducersDataGridVisibility
        {
            get { return _producersDataGridVisibility; }
            set
            {
                _producersDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _stocksDataGridVisibility;
        public Visibility StocksDataGridVisibility
        {
            get { return _stocksDataGridVisibility; }
            set
            {
                _stocksDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _categoriesDataGridVisibility;
        public Visibility CategoriesDataGridVisibility
        {
            get { return _categoriesDataGridVisibility; }
            set
            {
                _categoriesDataGridVisibility = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Form Varibles
        private Visibility _usersFormVisibility;
        public Visibility UsersFormVisibility
        {
            get { return _usersFormVisibility; }
            set
            {
                _usersFormVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _productsFormVisibility;
        public Visibility ProductsFormVisibility
        {
            get { return _productsFormVisibility; }
            set
            {
                _productsFormVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _producersFormVisibility;
        public Visibility ProducersFormVisibility
        {
            get { return _producersFormVisibility; }
            set
            {
                _producersFormVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _stocksFormVisibility;
        public Visibility StocksFormVisibility
        {
            get { return _stocksFormVisibility; }
            set
            {
                _stocksFormVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _categoriesFormVisibility;
        public Visibility CategoriesFormVisibility
        {
            get { return _categoriesFormVisibility; }
            set
            {
                _categoriesFormVisibility = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Visibility Controls
        private Visibility _viewControlsVisibility;
        public Visibility ViewControlsVisibility
        {
            get { return _viewControlsVisibility; }
            set
            {
                _viewControlsVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _addControlsVisibility;
        public Visibility AddControlsVisibility
        {
            get { return _addControlsVisibility; }
            set
            {
                _addControlsVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _editControlsVisibility;
        public Visibility EditControlsVisibility
        {
            get { return _editControlsVisibility; }
            set
            {
                _editControlsVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility _formsVisibility;
        public Visibility FormsVisibility
        {
            get { return _formsVisibility; }
            set
            {
                _formsVisibility = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Visibility Functions
        private void ShowUsersDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Visible;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;

            AddCommand = AddUserCommand;
            SaveCommand = EditUserCommand;
            DeleteCommand = DeleteUserCommand;

            UsersFormVisibility = Visibility.Visible;
            ProductsFormVisibility = Visibility.Collapsed;
            ProducersFormVisibility = Visibility.Collapsed;
            StocksFormVisibility = Visibility.Collapsed;
            CategoriesFormVisibility = Visibility.Collapsed;
        }
        private void ShowProductsDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Visible;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;

            AddCommand = AddProductCommand;
            SaveCommand = EditProductCommand;
            DeleteCommand = DeleteProductCommand;

            UsersFormVisibility = Visibility.Collapsed;
            ProductsFormVisibility = Visibility.Visible;
            ProducersFormVisibility = Visibility.Collapsed;
            StocksFormVisibility = Visibility.Collapsed;
            CategoriesFormVisibility = Visibility.Collapsed;
        }
        private void ShowProducersDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Visible;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Collapsed;

            AddCommand = AddProducerCommand;
            SaveCommand = EditProducerCommand;
            DeleteCommand = DeleteProducerCommand;

            UsersFormVisibility = Visibility.Collapsed;
            ProductsFormVisibility = Visibility.Collapsed;
            ProducersFormVisibility = Visibility.Visible;
            StocksFormVisibility = Visibility.Collapsed;
            CategoriesFormVisibility = Visibility.Collapsed;
        }
        private void ShowStocksDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Visible;
            CategoriesDataGridVisibility = Visibility.Collapsed;

            AddCommand = AddProductStockCommand;
            SaveCommand = EditProductStockCommand;
            DeleteCommand = DeleteProductStockCommand;

            UsersFormVisibility = Visibility.Collapsed;
            ProductsFormVisibility = Visibility.Collapsed;
            ProducersFormVisibility = Visibility.Collapsed;
            StocksFormVisibility = Visibility.Visible;
            CategoriesFormVisibility = Visibility.Collapsed;
        }
        private void ShowCategoriesDataGrid(object obj)
        {
            UsersDataGridVisibility = Visibility.Collapsed;
            ProductsDataGridVisibility = Visibility.Collapsed;
            ProducersDataGridVisibility = Visibility.Collapsed;
            StocksDataGridVisibility = Visibility.Collapsed;
            CategoriesDataGridVisibility = Visibility.Visible;

            AddCommand = AddCategoryCommand;
            SaveCommand = EditCategoryCommand;
            DeleteCommand = DeleteCategoryCommand;

            UsersFormVisibility = Visibility.Collapsed;
            ProductsFormVisibility = Visibility.Collapsed;
            ProducersFormVisibility = Visibility.Collapsed;
            StocksFormVisibility = Visibility.Collapsed;
            CategoriesFormVisibility = Visibility.Visible;
        }
        #endregion

        #region Commands

        #region Visibility Commands
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
        #endregion
        
        #region Navigation Commands
        public void GoView()
        {
            _currentMode = ModeType.View;
            ViewControlsVisibility = Visibility.Visible;
            AddControlsVisibility = Visibility.Hidden;
            EditControlsVisibility = Visibility.Hidden;
            FormsVisibility = Visibility.Hidden;

            if (_cancel)
            {
                UsersList = _adminBll.GetAllUsers();
                OnPropertyChanged("UsersList");

                ProductsList = _adminBll.GetAllProducts();
                OnPropertyChanged("ProductsList");

                ProducersList = _adminBll.GetAllProducers();
                OnPropertyChanged("ProducersList");

                ProductStocksList = _adminBll.GetAllProductStocks();
                OnPropertyChanged("ProductStocksList");

                CategoriesList = _adminBll.GetAllCategories();
                OnPropertyChanged("CategoriesList");
            }

            _cancel = false;
        }
        public void GoAdd()
        {
            _currentMode = ModeType.Add;

            CurrentUser = new select_user_Result();
            CurrentProduct = new select_product_Result();
            CurrentProducer = new select_producer_Result();
            CurrentStock = new select_stock_Result
            {
                expiration_date = System.DateTime.Today,
                supply_date = System.DateTime.Today
            };
            OnPropertyChanged("CurrentStock");
            CurrentCategory = new select_category_Result();

            ViewControlsVisibility = Visibility.Hidden;
            AddControlsVisibility = Visibility.Visible;
            EditControlsVisibility = Visibility.Hidden;
            FormsVisibility = Visibility.Visible;
        }
        public void GoEdit()
        {
            _currentMode = ModeType.Edit;

            ViewControlsVisibility = Visibility.Hidden;
            AddControlsVisibility = Visibility.Hidden;
            EditControlsVisibility = Visibility.Visible;
            FormsVisibility = Visibility.Visible;

            _cancel = true;
        }
        private ICommand _goViewCommand;
        public ICommand GoViewCommand
        {
            get
            {
                if (_goViewCommand == null)
                {
                    _goViewCommand = new RelayCommand(o => { _cancel = true; GoView(); }, o => true);
                }
                return _goViewCommand;
            }
        }
        private ICommand _goAddCommand;
        public ICommand GoAddCommand
        {
            get
            {
                if (_goAddCommand == null)
                {
                    _goAddCommand = new RelayCommand(o => { GoAdd(); }, o => true);
                }
                return _goAddCommand;
            }
        }
        private ICommand _goEditCommand;
        public ICommand GoEditCommand
        {
            get
            {
                if (_goEditCommand == null)
                {
                    _goEditCommand = new RelayCommand(o => { GoEdit(); }, o => true);
                }
                return _goEditCommand;
            }
        }
        #endregion

        #region Add Commands
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand;
            }
            set
            {
                _addCommand = value;
                OnPropertyChanged();
            }
        }
        public void AddUser()
        {
            _adminBll.AddUser(CurrentUser);
            OnPropertyChanged("UsersList");
            GoView();
        }
        private ICommand _addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                {
                    _addUserCommand = new RelayCommand(o => { AddUser(); }, o => true);
                }
                return _addUserCommand;
            }
        }
        public void AddProduct()
        {
            _adminBll.AddProduct(CurrentProduct); ;
            OnPropertyChanged("ProductsList");
            UpdateProductsComboBox();
            GoView();
        }
        private ICommand _addProductCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                {
                    _addProductCommand = new RelayCommand(o => { AddProduct(); }, o => true);
                }
                return _addProductCommand;
            }
        }
        public void AddProducer()
        {
            _adminBll.AddProducer(CurrentProducer);
            OnPropertyChanged("ProducersList");
            UpdateProducersComboBox();
            GoView();
        }
        private ICommand _addProducerCommand;
        public ICommand AddProducerCommand
        {
            get
            {
                if (_addProducerCommand == null)
                {
                    _addProducerCommand = new RelayCommand(o => { AddProducer(); }, o => true);
                }
                return _addProducerCommand;
            }
        }
        public void AddProductStock()
        {
            _adminBll.AddProductStock(CurrentStock);
            OnPropertyChanged("ProductStocksList");
            GoView();
        }
        private ICommand _addProductStockCommand;
        public ICommand AddProductStockCommand
        {
            get
            {
                if (_addProductStockCommand == null)
                {
                    _addProductStockCommand = new RelayCommand(o => { AddProductStock(); }, o => true);
                }
                return _addProductStockCommand;
            }
        }
        public void AddCategory()
        {
            _adminBll.AddCategory(CurrentCategory);
            OnPropertyChanged("CategoriesList");
            UpdateCategoriesComboBox();
            GoView();
        }
        private ICommand _addCategoryCommand;
        public ICommand AddCategoryCommand
        {
            get
            {
                if (_addCategoryCommand == null)
                {
                    _addCategoryCommand = new RelayCommand(o => { AddCategory(); }, o => true);
                }
                return _addCategoryCommand;
            }
        }
        #endregion

        #region Save Commands
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand;
            }
            set
            {
                _saveCommand = value;
                OnPropertyChanged();
            }
        }
        public void EditUser()
        {
            _adminBll.EditUser(CurrentUser);
            UsersList = _adminBll.GetAllUsers();
            _cancel = false;
            GoView();
        }
        private ICommand _editUserCommand;
        public ICommand EditUserCommand
        {
            get
            {
                if (_editUserCommand == null)
                {
                    _editUserCommand = new RelayCommand(o => { EditUser(); }, o => true);
                }
                return _editUserCommand;
            }
        }
        public void EditProduct()
        {
            _adminBll.EditProduct(CurrentProduct);
            ProductsList = _adminBll.GetAllProducts();
            _cancel = false;
            GoView();
        }
        private ICommand _editProductCommand;
        public ICommand EditProductCommand
        {
            get
            {
                if (_editProductCommand == null)
                {
                    _editProductCommand = new RelayCommand(o => { EditProduct(); }, o => true);
                }
                return _editProductCommand;
            }
        }
        public void EditProducer()
        {
            _adminBll.EditProducer(CurrentProducer);
            ProducersList = _adminBll.GetAllProducers();
            _cancel = false;
            GoView();
        }
        private ICommand _editProducerCommand;
        public ICommand EditProducerCommand
        {
            get
            {
                if (_editProducerCommand == null)
                {
                    _editProducerCommand = new RelayCommand(o => { EditProducer(); }, o => true);
                }
                return _editProducerCommand;
            }
        }
        public void EditProductStock()
        {
            _adminBll.EditProductStock(CurrentStock);
            ProductStocksList = _adminBll.GetAllProductStocks();
            _cancel = false;
            GoView();
        }
        private ICommand _editProductStockCommand;
        public ICommand EditProductStockCommand
        {
            get
            {
                if (_editProductStockCommand == null)
                {
                    _editProductStockCommand = new RelayCommand(o => { EditProductStock(); }, o => true);
                }
                return _editProductStockCommand;
            }
        }
        public void EditCategory()
        {
            _adminBll.EditCategory(CurrentCategory);
            CategoriesList = _adminBll.GetAllCategories();
            _cancel = false;
            GoView();
        }
        private ICommand _editCategoryCommand;
        public ICommand EditCategoryCommand
        {
            get
            {
                if (_editCategoryCommand == null)
                {
                    _editCategoryCommand = new RelayCommand(o => { EditCategory(); }, o => true);
                }
                return _editCategoryCommand;
            }
        }
        #endregion

        #region Delete Commands
        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
                OnPropertyChanged();
            }
        }
        public void DeleteUser()
        {
            _adminBll.DeleteUser(CurrentUser);
            OnPropertyChanged("UsersList");
            GoView();
        }
        private ICommand _deleteUserCommand;
        public ICommand DeleteUserCommand
        {
            get
            {
                if (_deleteUserCommand == null)
                {
                    _deleteUserCommand = new RelayCommand(o => { DeleteUser(); }, o => true);
                }
                return _deleteUserCommand;
            }
        }
        public void DeleteProduct()
        {
            _adminBll.DeleteProduct(CurrentProduct);
            OnPropertyChanged("ProductsList");
            UpdateProductsComboBox();
            GoView();
        }
        private ICommand _deleteProductCommand;
        public ICommand DeleteProductCommand
        {
            get
            {
                if (_deleteProductCommand == null)
                {
                    _deleteProductCommand = new RelayCommand(o => { DeleteProduct(); }, o => true);
                }
                return _deleteProductCommand;
            }
        }
        public void DeleteProducer()
        {
            _adminBll.DeleteProducer(CurrentProducer);
            OnPropertyChanged("ProducersList");
            UpdateProducersComboBox();
            GoView();
        }
        private ICommand _deleteProducerCommand;
        public ICommand DeleteProducerCommand
        {
            get
            {
                if (_deleteProducerCommand == null)
                {
                    _deleteProducerCommand = new RelayCommand(o => { DeleteProducer(); }, o => true);
                }
                return _deleteProducerCommand;
            }
        }
        public void DeleteProductStock()
        {
            _adminBll.DeleteProductStock(CurrentStock);
            OnPropertyChanged("ProductStocksList");
            GoView();
        }
        private ICommand _deleteProductStockCommand;
        public ICommand DeleteProductStockCommand
        {
            get
            {
                if (_deleteProductStockCommand == null)
                {
                    _deleteProductStockCommand = new RelayCommand(o => { DeleteProductStock(); }, o => true);
                }
                return _deleteProductStockCommand;
            }
        }
        public void DeleteCategory()
        {
            _adminBll.DeleteCategory(CurrentCategory);
            OnPropertyChanged("CategoriesList");
            UpdateCategoriesComboBox();
            GoView();
        }
        private ICommand _deleteCategoryCommand;
        public ICommand DeleteCategoryCommand
        {
            get
            {
                if (_deleteCategoryCommand == null)
                {
                    _deleteCategoryCommand = new RelayCommand(o => { DeleteCategory(); }, o => true);
                }
                return _deleteCategoryCommand;
            }
        }
        #endregion

        #endregion

        #region ComboBox Lists
        public List<string> UserTypesComboBox { get; set; }
        public List<string> CategoriesComboBox { get; set; }
        public List<string> ProducersComboBox { get; set; }
        public List<string> CountriesComboBox { get; set; }
        public List<string> ProductsComboBox { get; set; }
        public List<string> UnitsComboBox { get; set; }

        public void UpdateUserTypesComboBox() 
        {
            UserTypesComboBox.Clear();
            foreach(var type in _adminBll.GetAllUserTypes())
            {
                UserTypesComboBox.Add(type.name);
            }
        }
        public void UpdateCategoriesComboBox()
        {
            CategoriesComboBox.Clear();
            foreach (var category in _adminBll.GetAllCategories())
            {
                CategoriesComboBox.Add(category.name);
            }
        }
        public void UpdateProducersComboBox()
        {
            ProducersComboBox.Clear();
            foreach (var producer in _adminBll.GetAllProducers())
            {
                ProducersComboBox.Add(producer.name);
            }
        }
        public void UpdateCountriesComboBox()
        {
            CountriesComboBox.Clear();
            foreach (var country in _adminBll.GetAllCountry())
            {
                CountriesComboBox.Add(country.name);
            }
        }
        public void UpdateProductsComboBox()
        {
            ProductsComboBox.Clear();
            foreach (var product in _adminBll.GetAllProducts())
            {
                ProductsComboBox.Add(product.name);
            }
        }
        public void UpdateUnitsComboBox()
        {
            UnitsComboBox.Clear();
            foreach (var unit in _adminBll.GetAllUnits())
            {
                UnitsComboBox.Add(unit.name);
            }
        }

        #endregion
    }
}
