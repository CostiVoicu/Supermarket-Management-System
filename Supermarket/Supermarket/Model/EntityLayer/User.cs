using Supermarket.Core;
using System.Windows.Controls;

namespace Supermarket.Model.EntityLayer
{
    public class User : ObservableObject
    {
        private int? userId;
        public int? UserId
        {
            get 
            {
                return userId; 
            }
            set
            {
                userId = value;
                OnPropertyChanged("id");
            }
        }
        private string userName;
        public string UserNmae
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("name");
            }
        }
        private string userPassword;
        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            set
            {
                userPassword = value;
                OnPropertyChanged("password");
            }
        }
        private int? typeId;
        public int? TypeId
        {
            get
            {
                return typeId;
            }
            set
            {
                typeId = value;
                OnPropertyChanged("user_type_id");
            }
        }
    }
}
