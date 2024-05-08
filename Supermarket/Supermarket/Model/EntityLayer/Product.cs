using Supermarket.Core;

namespace Supermarket.Model.EntityLayer
{
    public class Product : ObservableObject
    {
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
                OnPropertyChanged("id");
            }
        }
        private string productName;
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("name");
            }
        }
        private string barCode;
        public string BarCode
        {
            get
            {
                return barCode;
            }
            set
            {
                barCode = value;
                OnPropertyChanged("bar_code");
            }
        }
        private int? categoryId;
        public int? CategoryId
        {
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                OnPropertyChanged("category_id");
            }
        }
        private int? producerId;
        public int? ProducerId
        {
            get
            {
                return producerId;
            }
            set
            {
                producerId = value;
                OnPropertyChanged("producer_id");
            }
        }
    }
}
