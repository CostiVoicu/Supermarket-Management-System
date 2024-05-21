using Supermarket.Core;
using Supermarket.Model;
using Supermarket.Model.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Supermarket.ViewModel
{
    public class CashierViewModel : Core.ViewModel
    {
        private AdminBLL _adminBLL;
        public int UserId { get; set; }
        public CashierViewModel(int id)
        {
            UserId = id;

            _adminBLL = new AdminBLL();

            ProductsList = _adminBLL.GetAllStocksProducts();
            DeleteExpiredStocks();
            ProductsList = _adminBLL.GetAllStocksProducts();
            SortProductsListByExpirationDate();
            CurrentProduct = new StockProductViewModel();
            FilteredProductsList = CollectionViewSource.GetDefaultView(ProductsList);
            FilteredProductsList.Filter = FilterProducts;
            CurrentSearch = "";
            CurrentTotal = 0;
            CurrentQuantity = 1;
            CurrentReceipt = new receipt
            {
                id = -1
            };
            ReceiptProductsList = new ObservableCollection<StockProductViewModel>();
        }
        private double _currentTotal;
        public double CurrentTotal
        {
            get { return _currentTotal; }
            set
            {
                _currentTotal = value;
                OnPropertyChanged();
            }
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
        private StockProductViewModel _currentProduct;
        public StockProductViewModel CurrentProduct
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
        private double _currentQuantity;
        public double CurrentQuantity
        {
            get { return _currentQuantity; }
            set
            {
                _currentQuantity = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<StockProductViewModel> _receiptProductsList;
        public ObservableCollection<StockProductViewModel> ReceiptProductsList
        {
            get { return _receiptProductsList; }
            set
            {
                _receiptProductsList = value;
                OnPropertyChanged();
            }
        }
        public receipt CurrentReceipt { get; set; }
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
        void AddProduct()
        {
            if (CurrentProduct.Id != -1)
            {
                if (!CheckStockQuantiy())
                {
                    MessageBox.Show("There is not enough on stock!");
                }
                else
                {
                    if (CurrentReceipt.id == -1)
                    {
                        CurrentReceipt = new receipt();
                        CurrentReceipt.user_id = UserId;
                        int newId = -1;
                        _adminBLL.AddReceipt(CurrentReceipt, ref newId);
                        CurrentReceipt.id = newId;
                    }
                    if (_adminBLL.AddSoldProduct(new sold_products
                    {
                        product_id = CurrentProduct.ProductId,
                        receipt_id = CurrentReceipt.id
                    }))
                    {
                        if (_adminBLL.EditProductStockQuantity(CurrentProduct.Id, CurrentQuantity))
                        {
                            CurrentProduct.Quantity = CurrentQuantity;
                            CurrentProduct.SellingPrice = CurrentProduct.Quantity * CurrentProduct.SellingPrice;
                            CurrentTotal += CurrentProduct.SellingPrice;
                            ReceiptProductsList.Add(CurrentProduct);
                            ProductsList.Remove(CurrentProduct);
                            CurrentQuantity = 1;
                            CurrentProduct = new StockProductViewModel();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't add product!");
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to select a product!");
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
        void FinishReceipt()
        {
            CurrentReceipt.release_date = DateTime.Now;
            CurrentReceipt.total = CurrentTotal;
            if (_adminBLL.EditReceipt(CurrentReceipt))
            {
                CurrentTotal = 0;
                ReceiptProductsList.Clear();
                CurrentReceipt = new receipt
                {
                    id = -1
                };
                ProductsList = _adminBLL.GetAllStocksProducts();
                SortProductsListByExpirationDate();
                OnPropertyChanged("ProductsList");
            }
        }
        private ICommand _finishReceiptCommand;
        public ICommand FinishReceiptCommand
        {
            get
            {
                if (_finishReceiptCommand == null)
                {
                    _finishReceiptCommand = new RelayCommand(o => { FinishReceipt(); }, o => true);
                }
                return _finishReceiptCommand;
            }
        }
        private void SortProductsListByExpirationDate()
        {
            List<StockProductViewModel> stockProductList = ProductsList.ToList();
            stockProductList.Sort((l, r) => r.ExpirationDate.CompareTo(l.ExpirationDate));
            ProductsList = new ObservableCollection<StockProductViewModel>(stockProductList);
        }
        private bool CheckStockQuantiy()
        {
            StockViewModel currentStock = _adminBLL.GetStock(CurrentProduct.Id);
            if (currentStock.Quantity - CurrentQuantity < 0)
            {
                return false;
            }
            return true;
        }
        private void DeleteExpiredStocks()
        {
            foreach(var stock in ProductsList)
            {
                DateTime date = DateTime.Parse(stock.ExpirationDate);
                if (date.CompareTo(DateTime.Now) < 0)
                {
                    _adminBLL.DeleteProductStock(_adminBLL.GetStock(stock.Id));
                }
            }
        }
    }
}
