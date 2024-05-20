using Supermarket.Core;
using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModel
{
    public class StockViewModel : ObservableObject
    {
        private readonly select_stock_Result _stock;
        public StockViewModel(select_stock_Result stock)
        {
            _stock = stock;
        }
        public int Id => _stock.id;
        public string Unit
        {
            get => _stock.name;
            set
            {
                _stock.name = value;
                OnPropertyChanged();
            }
        }
        public string Product
        {
            get => _stock.product;
            set
            {
                _stock.product= value;
                OnPropertyChanged();
            }
        }
        public double Quantity
        {
            get => _stock.quantity;
            set
            {
                _stock.quantity = value;
                OnPropertyChanged();
            }
        }
        public double PurchasePrice
        {
            get => _stock.purchase_price;
            set
            {
                _stock.purchase_price = value;
                OnPropertyChanged();
            }
        }
        public double SellingPrice
        {
            get => _stock.selling_price;
            set
            {
                _stock.selling_price = value;
                OnPropertyChanged();
            }
        }
        public DateTime SupplyDate
        {
            get => _stock.supply_date;
            set
            {
                _stock.supply_date = value;
                OnPropertyChanged();
            }
        }
        public DateTime ExpirationDate
        {
            get => _stock.expiration_date;
            set
            {
                _stock.expiration_date = value;
                OnPropertyChanged();
            }
        }
    }
}
