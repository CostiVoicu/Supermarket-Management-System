using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model.BusinessLogicLayer
{
    public class LogInBLL
    {
        private SupermarketDBEntities context = new SupermarketDBEntities();
        public ObservableCollection<user> UsersList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddMethod(object obj)
        {
            user usr = obj as user;
            if (usr != null)
            {
                if (string.IsNullOrEmpty(usr.name))
                {
                    ErrorMessage = "User name is empty!";
                }
                else
                {
                    if (usr.user_type_id == 1)
                    {
                        context.insert_user(usr.name, usr.password, "Admin");
                    }
                    else
                    {
                        context.insert_user(usr.name, usr.password, "Cashier");
                    }
                    context.SaveChanges();
                    //TO DO: maybe you should assign the id
                    UsersList.Add(usr);
                    ErrorMessage = "";
                }
            }
        }
        public ObservableCollection<user> GetAllUsers()
        {
            List<user> users = context.users.ToList();
            ObservableCollection<user> result = new ObservableCollection<user>();
            foreach (user user in users)
            {
                result.Add(user);
            }
            return result;
        }
    }
}
