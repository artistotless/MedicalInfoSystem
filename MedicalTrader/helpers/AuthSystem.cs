using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{

    static class AuthSystem
    {
        static private DBWrapper db;
        static private List<User> users = new List<User>();
        static public bool isInit;
        static public User Login(string login, string pass)
        {
            if (!isInit) { Init(); }
            if (users.Count > 0)
            {
                try
                {
                    return users.First(u => u.login == login && u.password == pass);
                }
                catch { return null; }
            }

            return null;
        }
        static public void Init()
        {
            if (db == null) { db = new DBWrapper(); }
            var lol = db.Users;

            if (users.Count <= 0) { users = db.Users.ToList(); }

            isInit = true;

        }
    }
}
