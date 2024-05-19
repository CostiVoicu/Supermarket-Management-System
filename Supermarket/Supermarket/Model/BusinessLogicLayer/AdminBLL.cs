using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.Model.BusinessLogicLayer
{
    public class AdminBLL
    {
        private SupermarketDBEntities context = new SupermarketDBEntities();
        public string ErrorMessage { get; set; }
        #region Entities Lists
        public ObservableCollection<select_user_Result> UsersList { get; set; }
        public ObservableCollection<select_user_Result> GetAllUsers()
        {
            List<user> users = context.users.ToList();
            ObservableCollection<select_user_Result> result = new ObservableCollection<select_user_Result>();
            foreach(user user in users)
            {
                if (user.active)
                {
                    result.Add(new select_user_Result
                    {
                        id = user.id,
                        name = user.name,
                        password = user.password,
                        type = user.user_types.name
                    });
                }
            }
            return result;
        }
        public ObservableCollection<select_product_Result> ProductsList { get; set; }
        public ObservableCollection<select_product_Result> GetAllProducts()
        {
            List<product> products = context.products.ToList();
            ObservableCollection<select_product_Result> result = new ObservableCollection<select_product_Result>();
            foreach (product product in products)
            {
                if (product.active)
                {
                    result.Add(new select_product_Result
                    {
                        id = product.id,
                        name = product.name,
                        bar_code = product.bar_code,
                        category = product.product_categories.name,
                        producer = product.producer.name
                    });
                }
            }
            return result;
        }
        public ObservableCollection<select_producer_Result> ProducersList { get; set; }
        public ObservableCollection<select_producer_Result> GetAllProducers()
        {
            List<producer> producers = context.producers.ToList();
            ObservableCollection<select_producer_Result> result = new ObservableCollection<select_producer_Result>();
            foreach (producer producer in producers)
            {
                if (producer.active)
                {
                    result.Add(new select_producer_Result
                    {
                        id = producer.id,
                        name = producer.name,
                        country = producer.country.name
                    });
                }
            }
            return result;
        }
        public ObservableCollection<select_stock_Result> ProductStocksList { get; set; }
        public ObservableCollection<select_stock_Result> GetAllProductStocks()
        {
            List<product_stock> product_stocks = context.product_stock.ToList();
            ObservableCollection<select_stock_Result> result = new ObservableCollection<select_stock_Result>();
            foreach (product_stock product_stock in product_stocks)
            {
                if (product_stock.active)
                {
                    result.Add(new select_stock_Result
                    {
                        id = product_stock.id,
                        product = product_stock.product.name,
                        quantity = product_stock.quantity,
                        purchase_price = product_stock.purchase_price,
                        selling_price = product_stock.selling_price,
                        name = product_stock.measuring_unit.name,
                        supply_date = product_stock.supply_date,
                        expiration_date = product_stock.expiration_date
                    });
                }
            }
            return result;
        }
        public ObservableCollection<select_category_Result> CategoriesList { get; set; }
        public ObservableCollection<select_category_Result> GetAllCategories()
        {
            List<product_categories> product_categories = context.product_categories.ToList();
            ObservableCollection<select_category_Result> result = new ObservableCollection<select_category_Result>();
            foreach (product_categories product_category in product_categories)
            {
                if (product_category.active)
                {
                    result.Add(new select_category_Result
                    {
                        id = product_category.id,
                        name = product_category.name
                    });
                }
            }
            return result;
        }
        public ObservableCollection<string> UnitsList { get; set; }
        public ObservableCollection<select_units_Result> GetAllUnits()
        {
            List<select_units_Result> units = context.select_units().ToList();
            ObservableCollection<select_units_Result> result = new ObservableCollection<select_units_Result>();
            foreach(select_units_Result unit in units)
            {
                result.Add(new select_units_Result
                {
                    id = unit.id,
                    name = unit.name
                });
            }
            return result;
        }
        public ObservableCollection<select_user_types_Result> UserTypesList { get; set; }
        public ObservableCollection<select_user_types_Result> GetAllUserTypes()
        {
            List<select_user_types_Result> types = context.select_user_types().ToList();
            ObservableCollection<select_user_types_Result> result = new ObservableCollection<select_user_types_Result>();
            foreach (select_user_types_Result type in types)
            {
                result.Add(new select_user_types_Result
                {
                    id = type.id,
                    name = type.name
                });
            }
            return result;
        }
        public ObservableCollection<select_countries_Result> CountriesList { get; set; }
        public ObservableCollection<select_countries_Result> GetAllCountry()
        {
            List<select_countries_Result> countries = context.select_countries().ToList();
            ObservableCollection<select_countries_Result> result = new ObservableCollection<select_countries_Result>();
            foreach (select_countries_Result country in countries)
            {
                result.Add(new select_countries_Result
                {
                    id = country.id,
                    name = country.name
                });
            }
            return result;
        }

        #endregion

        #region Add Functions
        public void AddUser(object obj)
        {
            select_user_Result user = obj as select_user_Result;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.name))
                {
                    ErrorMessage = "The name can't be empty";
                }
                else
                {
                    context.insert_user(user.name, user.password, user.type);
                    context.SaveChanges();
                    UsersList.Add(user);
                    ErrorMessage = "";
                }
            }
        }
        public void AddProduct(object obj)
        {
            select_product_Result product = obj as select_product_Result;
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.name))
                {
                    ErrorMessage = "The name can't be empty";
                }
                else
                {
                    context.insert_product(product.name, product.bar_code, product.category, product.producer);
                    context.SaveChanges();
                    ProductsList.Add(product);
                    ErrorMessage = "";
                }
            }
        }
        public void AddProducer(object obj)
        {
            select_producer_Result producer = obj as select_producer_Result;
            if (producer != null)
            {
                if (string.IsNullOrEmpty(producer.name))
                {
                    ErrorMessage = "The name can't be empty";
                }
                else
                {
                    context.insert_producer(producer.name, producer.country);
                    context.SaveChanges();
                    ProducersList.Add(producer);
                    ErrorMessage = "";
                }
            }
        }
        public void AddProductStock(object obj)
        {
            select_stock_Result stock = obj as select_stock_Result;
            if (stock != null)
            {
                if (string.IsNullOrEmpty(stock.product))
                {
                    ErrorMessage = "The name can't be empty";
                }
                else
                {
                    context.insert_product_stock(
                        stock.product, 
                        stock.quantity,
                        stock.purchase_price,
                        stock.selling_price,
                        stock.name,
                        stock.supply_date,
                        stock.expiration_date);
                    context.SaveChanges();
                    ProductStocksList.Add(stock);
                    ErrorMessage = "";
                }
            }
        }
        public void AddCategory(object obj)
        {
            select_category_Result category = obj as select_category_Result;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.name))
                {
                    ErrorMessage = "The name can't be empty";
                }
                else
                {
                    context.insert_category(category.name);
                    context.SaveChanges();
                    CategoriesList.Add(category);
                    ErrorMessage = "";
                }
            }
        }
        #endregion

        #region Edit Functions
        public void EditUser(object obj)
        {
            select_user_Result user = obj as select_user_Result; 
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.name))
                {
                    ErrorMessage = "Select a user";
                }
                else
                {
                    context.edit_user(user.id, user.name, user.password, user.type);
                    context.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }
        public void EditProduct(object obj)
        {
            select_product_Result product = obj as select_product_Result;
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.name))
                {
                    ErrorMessage = "Select a product";
                }
                else
                {
                    context.edit_product(product.id, product.name, product.bar_code, product.category, product.producer);
                    context.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }
        public void EditProducer(object obj)
        {
            select_producer_Result producer = obj as select_producer_Result;
            if (producer != null)
            {
                if (string.IsNullOrEmpty(producer.name))
                {
                    ErrorMessage = "Select a producer";
                }
                else
                {
                    context.edit_producer(producer.id, producer.name, producer.country);
                    context.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }
        public void EditProductStock(object obj)
        {
            select_stock_Result stock = obj as select_stock_Result;
            if (stock != null)
            {
                if (string.IsNullOrEmpty(stock.name))
                {
                    ErrorMessage = "Select a stock";
                }
                else
                {
                    context.edit_stock(stock.id,
                        stock.product,
                        stock.quantity,
                        stock.purchase_price,
                        stock.selling_price,
                        stock.name,
                        stock.supply_date,
                        stock.expiration_date);
                    context.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }
        public void EditCategory(object obj)
        {
            select_category_Result category = obj as select_category_Result;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.name))
                {
                    ErrorMessage = "Select a category";
                }
                else
                {
                    context.edit_category(category.id, category.name);
                    context.SaveChanges();
                    ErrorMessage = "";
                }
            }
        }
        #endregion

        #region Delete Functions
        public void DeleteUser(object obj)
        {
            select_user_Result user = obj as select_user_Result;
            if (user == null)
            {
                ErrorMessage = "Selecteaza o persoana";
            }
            else
            {
                //TO DO: validation for delete
                context.delete_user(user.id);
                context.SaveChanges();
                UsersList.Remove(user);
                ErrorMessage = "";
            }
        }
        public void DeleteProduct(object obj)
        {
            select_product_Result product = obj as select_product_Result;
            if (product == null)
            {
                ErrorMessage = "Selecteaza o persoana";
            }
            else
            {
                //TO DO: validation for delete
                context.delete_product(product.id);
                context.SaveChanges();
                ProductsList.Remove(product);
                ErrorMessage = "";
            }
        }
        public void DeleteProducer(object obj)
        {
            select_producer_Result producer = obj as select_producer_Result;
            if (producer == null)
            {
                ErrorMessage = "Selecteaza o persoana";
            }
            else
            {
                //TO DO: validation for delete
                context.delete_producer(producer.id);
                context.SaveChanges();
                ProducersList.Remove(producer);
                ErrorMessage = "";
            }
        }
        public void DeleteProductStock(object obj)
        {
            select_stock_Result product_stock = obj as select_stock_Result;
            if (product_stock == null)
            {
                ErrorMessage = "Selecteaza o persoana";
            }
            else
            {
                //TO DO: validation for delete
                context.delete_stock(product_stock.id);
                context.SaveChanges();
                ProductStocksList.Remove(product_stock);
                ErrorMessage = "";
            }
        }
        public void DeleteCategory(object obj)
        {
            select_category_Result product_category = obj as select_category_Result;
            if (product_category == null)
            {
                ErrorMessage = "Selecteaza o persoana";
            }
            else
            {
                //TO DO: validation for delete
                context.delete_category(product_category.id);
                context.SaveChanges();
                CategoriesList.Remove(product_category);
                ErrorMessage = "";
            }
        }
        #endregion
    }
}
