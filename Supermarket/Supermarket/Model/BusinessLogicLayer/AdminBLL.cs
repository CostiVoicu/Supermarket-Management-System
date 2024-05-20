using Supermarket.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

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
        public ObservableCollection<ProductViewModel> ProductsList { get; set; }
        public ObservableCollection<ProductViewModel> GetAllProducts()
        {
            List<product> products = context.products.ToList();
            ObservableCollection<ProductViewModel> result = new ObservableCollection<ProductViewModel>();
            foreach (product product in products)
            {
                if (product.active)
                {
                    select_product_Result p = new select_product_Result
                    {
                        id = product.id,
                        name = product.name,
                        bar_code = product.bar_code,
                        category = product.product_categories.name,
                        producer = product.producer.name
                    };
                    result.Add(new ProductViewModel(p));
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
        public ObservableCollection<StockViewModel> ProductStocksList { get; set; }
        public ObservableCollection<StockViewModel> GetAllProductStocks()
        {
            List<product_stock> product_stocks = context.product_stock.ToList();
            ObservableCollection<StockViewModel> result = new ObservableCollection<StockViewModel>();
            foreach (product_stock product_stock in product_stocks)
            {
                if (product_stock.active)
                {
                    result.Add(new StockViewModel(new select_stock_Result
                    {
                        id = product_stock.id,
                        product = product_stock.product.name,
                        quantity = product_stock.quantity,
                        purchase_price = product_stock.purchase_price,
                        selling_price = product_stock.selling_price,
                        name = product_stock.measuring_unit.name,
                        supply_date = product_stock.supply_date,
                        expiration_date = product_stock.expiration_date
                    }));
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
        public bool AddUser(object obj)
        {
            select_user_Result user = obj as select_user_Result;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.name))
                {
                    MessageBox.Show("The name can't be empty!");
                }
                else if (string.IsNullOrEmpty(user.password))
                {
                    MessageBox.Show("The password can't be empty!");
                }
                else if (string.IsNullOrEmpty(user.type))
                {
                    MessageBox.Show("The type can't be empty!");
                }
                else
                {
                    context.insert_user(user.name, user.password, user.type);
                    context.SaveChanges();
                    UsersList.Add(user);
                    return true;
                }
            }
            return false;
        }
        public bool AddProduct(object obj)
        {
            ProductViewModel product = obj as ProductViewModel;
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.Name))
                {
                    MessageBox.Show("The name can't be empty!");
                }
                else if (string.IsNullOrEmpty(product.BarCode))
                {
                    MessageBox.Show("The bar code can't be empty!");
                }
                else if (product.BarCode.Length != 12)
                {
                    MessageBox.Show("The bar code must be size of 12!");
                }
                else if (string.IsNullOrEmpty(product.Category))
                {
                    MessageBox.Show("The category can't be empty!");
                }
                else if (string.IsNullOrEmpty(product.Producer))
                {
                    MessageBox.Show("The producer can't be empty!");
                }
                else
                {
                    context.insert_product(product.Name, product.BarCode, product.Category, product.Producer);
                    context.SaveChanges();
                    ProductsList.Add(product);
                    return true;
                }
            }
            return false;
        }
        public bool AddProducer(object obj)
        {
            select_producer_Result producer = obj as select_producer_Result;
            if (producer != null)
            {
                if (string.IsNullOrEmpty(producer.name))
                {
                    MessageBox.Show("The name can't be empty!");
                }
                else if (string.IsNullOrEmpty(producer.country))
                {
                    MessageBox.Show("The producer can't be empty!");
                }
                else
                {
                    context.insert_producer(producer.name, producer.country);
                    context.SaveChanges();
                    ProducersList.Add(producer);
                    return true;
                }
            }
            return false;
        }
        public bool AddProductStock(object obj)
        {
            StockViewModel stock = obj as StockViewModel;
            if (stock != null)
            {
                if (string.IsNullOrEmpty(stock.Product))
                {
                    MessageBox.Show("The product can't be empty!");
                }
                else if (stock.Quantity < 0)
                {
                    MessageBox.Show("The quantity can't be negative!");
                }
                else if (stock.PurchasePrice < 0)
                {
                    MessageBox.Show("The purchase price can't be negative!");
                }
                else if (stock.SellingPrice < 0)
                {
                    MessageBox.Show("The purchase price can't be negative!");
                }
                else if (stock.SellingPrice < stock.PurchasePrice)
                {
                    MessageBox.Show("The selling price can't be smaller than purchase price!");
                }
                else if (string.IsNullOrEmpty(stock.Unit))
                {
                    MessageBox.Show("The unit can't be empty!");
                }
                else
                {
                    context.insert_product_stock(
                        stock.Product, 
                        stock.Quantity,
                        stock.PurchasePrice,
                        stock.SellingPrice,
                        stock.Unit,
                        stock.SupplyDate,
                        stock.ExpirationDate);
                    context.SaveChanges();
                    ProductStocksList.Add(stock);
                    return true;
                }
            }
            return false;
        }
        public bool AddCategory(object obj)
        {
            select_category_Result category = obj as select_category_Result;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.name))
                {
                    MessageBox.Show("The name can't be empty");
                }
                else
                {
                    context.insert_category(category.name);
                    context.SaveChanges();
                    CategoriesList.Add(category);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Edit Functions
        public bool EditUser(object obj)
        {
            select_user_Result user = obj as select_user_Result; 
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.name))
                {
                    MessageBox.Show("The name can't be empty!");
                }
                else if (string.IsNullOrEmpty(user.password))
                {
                    MessageBox.Show("The password can't be empty!");
                }
                else if (string.IsNullOrEmpty(user.type))
                {
                    MessageBox.Show("The type can't be empty!");
                }
                else
                {
                    context.edit_user(user.id, user.name, user.password, user.type);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool EditProduct(object obj)
        {
            ProductViewModel product = obj as ProductViewModel;
            if (product != null)
            {
                if (string.IsNullOrEmpty(product.Name))
                {
                    MessageBox.Show("The name can't be empty!");
                }
                else if (string.IsNullOrEmpty(product.BarCode))
                {
                    MessageBox.Show("The bar code can't be empty!");
                }
                else if (product.BarCode.Length < 12)
                {
                    MessageBox.Show("The bar code is too short, it must be size of 12!");
                }
                else if (string.IsNullOrEmpty(product.Category))
                {
                    MessageBox.Show("The category can't be empty!");
                }
                else if (string.IsNullOrEmpty(product.Producer))
                {
                    MessageBox.Show("The producer can't be empty!");
                }
                else
                {
                    context.edit_product(product.Id, product.Name, product.BarCode, product.Category, product.Producer);
                    context.SaveChanges();

                    context.Dispose();
                    context = new SupermarketDBEntities();
                    return true;
                }
            }
            return false;
        }
        public bool EditProducer(object obj)
        {
            select_producer_Result producer = obj as select_producer_Result;
            if (producer != null)
            {
                if (string.IsNullOrEmpty(producer.name))
                {
                    MessageBox.Show("The name can't be empty!");
                }
                else if (string.IsNullOrEmpty(producer.country))
                {
                    MessageBox.Show("The producer can't be empty!");
                }
                else
                {
                    context.edit_producer(producer.id, producer.name, producer.country);
                    context.SaveChanges();
                    context.Dispose();
                    context = new SupermarketDBEntities();
                    return true;
                }
            }
            return false;
        }
        public bool EditProductStock(object obj)
        {
            StockViewModel stock = obj as StockViewModel;
            if (stock != null)
            {
                if (string.IsNullOrEmpty(stock.Product))
                {
                    MessageBox.Show("The product can't be empty!");
                }
                else if (stock.Quantity < 0)
                {
                    MessageBox.Show("The quantity can't be negative!");
                }
                else if (stock.PurchasePrice < 0)
                {
                    MessageBox.Show("The purchase price can't be negative!");
                }
                else if (stock.SellingPrice < 0)
                {
                    MessageBox.Show("The purchase price can't be negative!");
                }
                else if (stock.SellingPrice < stock.PurchasePrice)
                {
                    MessageBox.Show("The selling price can't be smaller than purchase price!");
                }
                else if (string.IsNullOrEmpty(stock.Unit))
                {
                    MessageBox.Show("The unit can't be empty!");
                }
                else
                {
                    context.edit_stock(
                        stock.Id,
                        stock.Product,
                        stock.Quantity,
                        stock.PurchasePrice,
                        stock.SellingPrice,
                        stock.Unit,
                        stock.SupplyDate,
                        stock.ExpirationDate);
                    context.SaveChanges();
                    context.Dispose();
                    context = new SupermarketDBEntities();
                    return true;
                }
            }
            return false;
        }
        public bool EditCategory(object obj)
        {
            select_category_Result category = obj as select_category_Result;
            if (category != null)
            {
                if (string.IsNullOrEmpty(category.name))
                {
                    MessageBox.Show("The name can't be empty");
                }
                else
                {
                    context.edit_category(category.id, category.name);
                    context.SaveChanges();
                    context.Dispose();
                    context = new SupermarketDBEntities();
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Delete Functions
        public bool DeleteUser(object obj)
        {
            select_user_Result user = obj as select_user_Result;
            if (user == null)
            {
                MessageBox.Show("Select a user!");
            }
            else
            {
                user u = context.users.Where(i => i.id == user.id).FirstOrDefault();
                if (u.receipts.Count > 0)
                {
                    MessageBox.Show("The user has receipts liked to it!");
                }
                else
                {
                    context.delete_user(user.id);
                    context.SaveChanges();
                    UsersList.Remove(user);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteProduct(object obj)
        {
            ProductViewModel product = obj as ProductViewModel;
            if (product == null)
            {
                MessageBox.Show("Select a product!");
            }
            else
            {
                product p = context.products.Where(i => i.id == product.Id).FirstOrDefault();
                if (p.product_stock.Where(pr => pr.active == true).Count() > 0)
                {
                    MessageBox.Show("The product has product stocks linked to it!");
                }
                else
                {
                    context.delete_product(product.Id);
                    context.SaveChanges();
                    ProductsList.Remove(ProductsList.Where(u => u.Id == product.Id).First());

                    context.Dispose();
                    context = new SupermarketDBEntities();
                    return true;
                }
            }
            return false;
        }
        public bool DeleteProducer(object obj)
        {
            select_producer_Result producer = obj as select_producer_Result;
            if (producer == null)
            {
                MessageBox.Show("Select a producer!");
            }
            else
            {
                producer p = context.producers.Where(i => i.id == producer.id).FirstOrDefault();
                if (p.products.Where(pr => pr.active == true).Count() > 0)
                {
                    MessageBox.Show("The producer has products linked to it!");
                }
                else
                {
                    context.delete_producer(producer.id);
                    context.SaveChanges();
                    ProducersList.Remove(producer);
                    return true;
                }                
            }
            return false;
        }
        public void DeleteProductStock(object obj)
        {
            StockViewModel product_stock = obj as StockViewModel;
            if (product_stock == null)
            {
                MessageBox.Show("Select a product stock!");
            }
            else
            {
                context.delete_stock(product_stock.Id);
                context.SaveChanges();
                ProductStocksList.Remove(ProductStocksList.Where(s => s.Id == product_stock.Id).First());
                context.Dispose();
                context = new SupermarketDBEntities();
            }
        }
        public bool DeleteCategory(object obj)
        {
            select_category_Result product_category = obj as select_category_Result;
            if (product_category == null)
            {
                MessageBox.Show("Select a category!");
            }
            else
            {
                product_categories c = context.product_categories.Where(i => i.id==product_category.id).FirstOrDefault();
                if (c.products.Where(pr => pr.active == true).Count() > 0)
                {
                    MessageBox.Show("The category has products linked to it!");
                }
                else
                {
                    context.delete_category(product_category.id);
                    context.SaveChanges();
                    CategoriesList.Remove(product_category);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Select row Functions
        public select_user_Result GetUser(int id)
        {
            select_user_Result user = context.select_user(id).ToList()[0];
            if (user == null)
            {
                MessageBox.Show("The user was not found!");
            }
            return user;
        }
        public ProductViewModel GetProduct(int id)
        {
            select_product_Result product = context.select_product(id).ToList()[0];
            if (product == null)
            {
                MessageBox.Show("The product was not found!");
            }
            return new ProductViewModel(product);
        }
        public select_producer_Result GetProducer(int id)
        {
            select_producer_Result producer = context.select_producer(id).ToList()[0];
            if (producer != null)
            {
                MessageBox.Show("The producer was not found!");
            }
            return producer;
        }
        public select_category_Result GetCategory(int id)
        {
            select_category_Result category = context.select_category(id).ToList()[0];
            if (category != null)
            {
                MessageBox.Show("The category was not found!");
            }
            return category;
        }
        public StockViewModel GetStock(int id)
        {
            select_stock_Result stock = context.select_stock(id).ToList()[0];
            if (stock != null)
            {
                MessageBox.Show("The product stock was not found!");
            }
            return new StockViewModel(stock);
        }
        #endregion
    }
}
