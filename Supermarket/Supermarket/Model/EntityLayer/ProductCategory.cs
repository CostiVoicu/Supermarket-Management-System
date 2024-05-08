using Supermarket.Core;

namespace Supermarket.Model.EntityLayer
{
    public class ProductCategory : ObservableObject
    {
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
                OnPropertyChanged("id");
            }
        }
        private string categoryName;
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                OnPropertyChanged("name");
            }
        }
    }
}
