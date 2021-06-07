using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalTrader
{
    public class User
    {

        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public int role { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public User(int id, string login, string password, string fullName, int role, string phone, string email)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.fullName = fullName;
            this.role = role;
            this.phone = phone;
            this.email = email;
        }

        public User()
        {
        }
    }
}
