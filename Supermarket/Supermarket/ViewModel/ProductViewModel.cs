using Supermarket.Core;
using Supermarket.Model;

namespace Supermarket.ViewModel
{
    public class ProductViewModel : ObservableObject
    {
        private readonly select_product_Result _product;
        public ProductViewModel(select_product_Result product)
        {
            _product = product;
        }
        public int Id => _product.id;
        public string Name
        {
            get => _product.name;
            set
            {
                _product.name = value;
                OnPropertyChanged();
            }
        }
        public string BarCode
        {
            get => _product.bar_code;
            set
            {
                _product.bar_code = value;
                OnPropertyChanged();
            }
        }
        public string Category
        {
            get => _product.category;
            set
            {
                _product.category = value;
                OnPropertyChanged();
            }
        }
        public string Producer
        {
            get => _product.producer;
            set
            {
                _product.producer = value;
                OnPropertyChanged();
            }
        }
    }
}
