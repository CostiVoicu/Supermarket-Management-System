using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.Model.BusinessLogicLayer
{
    public class AdminBLL
    {
        private SupermarketDBEntities1 context = new SupermarketDBEntities1();
        public string ErrorMessage { get; set; }
        public ObservableCollection<select_user_Result> UsersList { get; set; }
        public ObservableCollection<select_user_Result> GetAllUsers()
        {
            List<user> users = context.users.ToList();
            ObservableCollection<select_user_Result> result = new ObservableCollection<select_user_Result>();
            foreach(user user in users)
            {
                result.Add(new select_user_Result
                {
                    name = user.name,
                    password = user.password,
                    type = user.user_types.name
                });
            }
            return result;
        }
        public ObservableCollection<product> ProductsList { get; set; }
        public ObservableCollection<product> GetAllProducts()
        {
            List<product> products = context.products.ToList();
            ObservableCollection<product> result = new ObservableCollection<product>();
            foreach (product product in products)
            {
                result.Add(product);
            }
            return result;
        }
        public ObservableCollection<producer> ProducersList { get; set; }
        public ObservableCollection<producer> GetAllProducers()
        {
            List<producer> producers = context.producers.ToList();
            ObservableCollection<producer> result = new ObservableCollection<producer>();
            foreach (producer producer in producers)
            {
                result.Add(producer);
            }
            return result;
        }
        public ObservableCollection<product_stock> ProductStocksList { get; set; }
        public ObservableCollection<product_stock> GetAllProductStocks()
        {
            List<product_stock> product_stocks = context.product_stock.ToList();
            ObservableCollection<product_stock> result = new ObservableCollection<product_stock>();
            foreach (product_stock product_stock in product_stocks)
            {
                result.Add(product_stock);
            }
            return result;
        }
        public ObservableCollection<product_categories> CategoriesList { get; set; }
        public ObservableCollection<product_categories> GetAllCategories()
        {
            List<product_categories> product_categoriess = context.product_categories.ToList();
            ObservableCollection<product_categories> result = new ObservableCollection<product_categories>();
            foreach (product_categories product_categories in product_categoriess)
            {
                result.Add(product_categories);
            }
            return result;
        }
    }
}
