using Supermarket.Core;
using System;
using System.Windows.Data;

namespace Supermarket.Model.EntityLayer
{
    public class ProductStock : ObservableObject
    {
        private int? stockId;
        public int? StockId
        {
            get
            {
                return stockId;
            }
            set
            {
                stockId = value;
                OnPropertyChanged("id");
            }
        }
        private float? stockQuantity;
        public float? StockQuantity
        {
            get
            {
                return stockQuantity;
            }
            set
            {
                stockQuantity = value;
                OnPropertyChanged("quantity");
            }
        }
        private DateTime? stockSupplyDate;
        public DateTime? StockSupplyDate
        {
            get
            {
                return stockSupplyDate;
            }
            set
            {
                stockSupplyDate = value;
                OnPropertyChanged("supply_date");
            }
        }
        private DateTime? stockExpirationDate;
        public DateTime? StockExpirationDate
        {
            get
            {
                return stockExpirationDate;
            }
            set
            {
                stockExpirationDate = value;
                OnPropertyChanged("expiration_date");
            }
        }
        private float? stockPurchasePrice;
        public float? StockPurchasePrice
        {
            get
            {
                return stockPurchasePrice;
            }
            set
            {
                stockPurchasePrice = value;
                OnPropertyChanged("purchase_price");
            }
        }
        private float? stockSellingPrice;
        public float? StockSellingPrice
        {
            get
            {
                return stockSellingPrice;
            }
            set
            {
                stockSellingPrice = value;
                OnPropertyChanged("supply_price");
            }
        }
        private int? productId;
        public int? ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                OnPropertyChanged("product_id");
            }
        }
        private int? unitId;
        public int? UnitId
        {
            get
            {
                return unitId;
            }
            set
            {
                unitId = value;
                OnPropertyChanged("unit_id");
            }
        }
    }
}
