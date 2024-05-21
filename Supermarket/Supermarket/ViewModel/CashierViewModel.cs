using Supermarket.Model;
using Supermarket.Model.BusinessLogicLayer;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Supermarket.ViewModel
{
    public class CashierViewModel : Core.ViewModel
    {
        private AdminBLL _adminBLL;
        public CashierViewModel()
        {
            _adminBLL = new AdminBLL();

            ProductsList = _adminBLL.GetAllStocksProducts();
            CurrentProduct = new ProductViewModel(new select_product_Result());
            FilteredProductsList = CollectionViewSource.GetDefaultView(ProductsList);
            FilteredProductsList.Filter = FilterProducts;
            CurrentSearch = "";
        }
        private ICollectionView _filteredProductsList;
        public ICollectionView FilteredProductsList
        {
            get { return _filteredProductsList; }
            set
            {
                _filteredProductsList = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StockProductViewModel> ProductsList
        {
            get => _adminBLL.StocksProducstsList;
            set => _adminBLL.StocksProducstsList = value;
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
        private string _currentSearch;
        public string CurrentSearch
        {
            get { return _currentSearch; }
            set
            {
                _currentSearch = value;
                OnPropertyChanged();
                FilteredProductsList.Refresh();
            }
        }
        private bool FilterProducts(object obj)
        {
            if (obj is StockProductViewModel product)
            {
                return string.IsNullOrWhiteSpace(CurrentSearch) ||
                    product.ProducerName.ToLower().Contains(CurrentSearch) ||
                    product.BarCode.Contains(CurrentSearch) ||
                    product.Category.ToLower().Contains(CurrentSearch) ||
                    product.ProducerName.ToLower().Contains(CurrentSearch) ||
                    product.ExpirationDate.ToLower().Contains(CurrentSearch);
            }
            return false;
        }
    }
}
