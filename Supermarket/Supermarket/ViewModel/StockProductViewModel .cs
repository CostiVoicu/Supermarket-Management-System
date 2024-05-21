using Supermarket.Core;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModel
{
    public class StockProductViewModel : ObservableObject
    {
        public StockProductViewModel()
        {
            Id = -1;
            _quantity = 0;
            _supplyDate = DateTime.Now;
            _expirationDate = DateTime.Now;
            _productName = "";
            _barCode = "";
            _category = "";
            _producerName = "";
            _sellingPrice = 0;
            _purchasePrice = 0;
            _unit = "";
            ProductId = -1;
        }
        public StockProductViewModel(int id, double quantity, DateTime supplyDate, DateTime expirationDate, string productName,
            string barCode, string category, string producerName, double sellingPrice,
            double purchasePrice, string unit, int productId)
        {
            Id = id;
            _quantity = quantity;
            _supplyDate = supplyDate;
            _expirationDate = expirationDate;
            _productName = productName;
            _barCode = barCode;
            _category = category;
            _producerName = producerName;
            _sellingPrice = sellingPrice;
            _purchasePrice = purchasePrice;
            _unit = unit;
            ProductId = productId;
        }
        public int Id { get; set; }
        private double _quantity;
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
        private DateTime _supplyDate;
        public DateTime SupplyDate
        {
            get { return _supplyDate; }
            set
            {
                _supplyDate = value;
                OnPropertyChanged();
            }
        }
        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                OnPropertyChanged();
            }
        }
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }
        private string _barCode;
        public string BarCode
        {
            get { return _barCode; }
            set
            {
                _barCode = value;
                OnPropertyChanged();
            }
        }
        private string _category;
        public String Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }
        private string _producerName;
        public string ProducerName
        {
            get { return _producerName; }
            set
            {
                _producerName = value;
                OnPropertyChanged();
            }
        }
        private double _sellingPrice;
        public double SellingPrice
        {
            get { return _sellingPrice; }
            set
            {
                _sellingPrice = value;
                OnPropertyChanged();
            }
        }
        private double _purchasePrice;
        public double PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                _purchasePrice = value;
                OnPropertyChanged();
            }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnPropertyChanged();
            }
        }
        public int ProductId { get; set; }
    }
}
