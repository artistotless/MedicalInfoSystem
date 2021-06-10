using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
    class Client
    {
        public int id { get; set; }
        public string companyName { get; set; }

        public string contactFace { get; set; }
        public string phone { get; set; }
        public string license { get; set; }
        public string inn { get; set; }

        public Client()
        {
        }

        public Client(int id, string companyName, string contactFace, string phone, string license, string inn)
        {
            this.id = id;
            this.companyName = companyName;
            this.contactFace = contactFace;
            this.phone = phone;
            this.license = license;
            this.inn = inn;
        }
    }
}
