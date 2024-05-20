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
    public class AdminViewModel : Core.ViewModel
    {
        private AdminBLL _adminBll;
        private bool _cancel;
        public AdminViewModel()
        {
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
            CurrentProduct = new ProductViewModel(new select_product_Result());
            CurrentProducer = new select_producer_Result();
            CurrentStock = new StockViewModel(new select_stock_Result());
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
        public ObservableCollection<ProductViewModel> ProductsList
        {
            get => _adminBll.ProductsList;
            set => _adminBll.ProductsList = value;
        }
        public ObservableCollection<select_producer_Result> ProducersList
        {
            get => _adminBll.ProducersList;
            set => _adminBll.ProducersList = value;
        }
        public ObservableCollection<StockViewModel> ProductStocksList
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
        private ProductViewModel _currentProduct;
        public ProductViewModel CurrentProduct
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
        private StockViewModel _currentStock;
        public StockViewModel CurrentStock
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

            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();
        }
        private void ShowProductsDataGrid(object obj)
        {
            ProductsList = _adminBll.GetAllProducts();
            OnPropertyChanged("ProductsList");
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

            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();
        }
        private void ShowProducersDataGrid(object obj)
        {
            
            OnPropertyChanged("ProducersList");
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

            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();
        }
        private void ShowStocksDataGrid(object obj)
        {
            ProductStocksList = _adminBll.GetAllProductStocks();
            OnPropertyChanged("ProductStocksList");
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

            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();
        }
        private void ShowCategoriesDataGrid(object obj)
        {
            OnPropertyChanged("CategoriesList");
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

            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();
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
            ViewControlsVisibility = Visibility.Visible;
            AddControlsVisibility = Visibility.Hidden;
            EditControlsVisibility = Visibility.Hidden;
            FormsVisibility = Visibility.Hidden;

            if (_cancel)
            {
                UndoChanges();
            }

            UpdateCategoriesComboBox();
            UpdateProducersComboBox();
            UpdateProductsComboBox();

            _cancel = false;
        }
        public void GoAdd()
        {
            CurrentUser = new select_user_Result();
            CurrentProduct = new ProductViewModel(new select_product_Result());
            CurrentProducer = new select_producer_Result();
            CurrentStock = new StockViewModel(new select_stock_Result
            {
                expiration_date = System.DateTime.Today,
                supply_date = System.DateTime.Today
            });
            OnPropertyChanged("CurrentStock");
            CurrentCategory = new select_category_Result();

            ViewControlsVisibility = Visibility.Hidden;
            AddControlsVisibility = Visibility.Visible;
            EditControlsVisibility = Visibility.Hidden;
            FormsVisibility = Visibility.Visible;
        }
        public void GoEdit()
        {
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
            if (_adminBll.AddUser(CurrentUser))
            {
                OnPropertyChanged("UsersList");
                GoView();
            }
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
            if (_adminBll.AddProduct(CurrentProduct))
            {
                OnPropertyChanged("ProductsList");
                UpdateProductsComboBox();
                GoView();
            }
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
            if (_adminBll.AddProducer(CurrentProducer))
            {
                OnPropertyChanged("ProducersList");
                UpdateProducersComboBox();
                GoView();
            }
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
            if (_adminBll.AddProductStock(CurrentStock))
            {
                OnPropertyChanged("ProductStocksList");
                GoView();
            }
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
            if (_adminBll.AddCategory(CurrentCategory))
            {
                OnPropertyChanged("CategoriesList");
                UpdateCategoriesComboBox();
                GoView();
            }
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
            if (_adminBll.EditUser(CurrentUser))
            {
                UsersList = _adminBll.GetAllUsers();
                OnPropertyChanged("UsersList");
                _cancel = false;
                GoView();
            }
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
            if (_adminBll.EditProduct(CurrentProduct))
            {
                ProductsList = _adminBll.GetAllProducts();
                OnPropertyChanged("ProductsList");
                _cancel = false;
                GoView();
            }
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
            if (_adminBll.EditProducer(CurrentProducer))
            {
                ProducersList = _adminBll.GetAllProducers();
                OnPropertyChanged("ProducersList");
                _cancel = false;
                GoView();
            }
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
            if (_adminBll.EditProductStock(CurrentStock))
            {
                ProductStocksList = _adminBll.GetAllProductStocks();
                OnPropertyChanged("ProductStocksList");
                _cancel = false;
                GoView();
            }
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
            if (_adminBll.EditCategory(CurrentCategory))
            {
                CategoriesList = _adminBll.GetAllCategories();
                OnPropertyChanged("CategoriesList");
                _cancel = false;
                GoView();
            }
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
            if (_adminBll.DeleteUser(CurrentUser))
            {
                OnPropertyChanged("UsersList");
                GoView();
            }
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
            if (_adminBll.DeleteProduct(CurrentProduct))
            {
                OnPropertyChanged("ProductsList");
                UpdateProductsComboBox();
                GoView();
            }
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
            if (_adminBll.DeleteProducer(CurrentProducer))
            {
                OnPropertyChanged("ProducersList");
                UpdateProducersComboBox();
                GoView();
            }
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
            if (_adminBll.DeleteCategory(CurrentCategory))
            {
                OnPropertyChanged("CategoriesList");
                UpdateCategoriesComboBox();
                GoView();
            }
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
            foreach (var category in CategoriesList)
            {
                CategoriesComboBox.Add(category.name);
            }
        }
        public void UpdateProducersComboBox()
        {
            ProducersComboBox.Clear();
            foreach (var producer in ProducersList)
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
            foreach (var product in ProductsList)
            {
                ProductsComboBox.Add(product.Name);
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

        private void UndoChanges() 
        {
            var currentUserIndex = UsersList.IndexOf(CurrentUser);
            if (currentUserIndex >= 0)
            {
                CurrentUser = _adminBll.GetUser(CurrentUser.id);
                UsersList[currentUserIndex] = CurrentUser;
                OnPropertyChanged("UsersList");
            }

            var product = ProductsList.Where(p => p.Id == CurrentProduct.Id).FirstOrDefault();
            var currentProductIndex = ProductsList.IndexOf(product);
            if (currentProductIndex >= 0)
            {
                CurrentProduct = _adminBll.GetProduct(CurrentProduct.Id);
                ProductsList[currentProductIndex] = CurrentProduct;
                OnPropertyChanged("ProductsList");
            }

            var currentProducerIndex = ProducersList.IndexOf(CurrentProducer);
            if (currentProducerIndex >= 0)
            {
                CurrentProducer = _adminBll.GetProducer(CurrentProducer.id);
                ProducersList[currentProducerIndex] = CurrentProducer;
                OnPropertyChanged("ProducersList");
            }

            var currentStockIndex = ProductStocksList.IndexOf(CurrentStock);
            if (currentStockIndex >= 0)
            {
                CurrentStock = _adminBll.GetStock(CurrentStock.Id);
                ProductStocksList[currentStockIndex] = CurrentStock;
                OnPropertyChanged("ProductStocksList");
            }

            var category = CategoriesList.Where(c => c.id == CurrentCategory.id).FirstOrDefault();
            var currentCategoryIndex = CategoriesList.IndexOf(category);
            if (currentCategoryIndex >= 0)
            {
                CurrentCategory = _adminBll.GetCategory(category.id);
                CategoriesList[currentCategoryIndex] = CurrentCategory;
                OnPropertyChanged("CategoriesList");
            }
        }
    }
}
