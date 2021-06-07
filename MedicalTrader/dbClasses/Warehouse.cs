using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalTrader
{
    public class Warehouse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string adress { get; set; }
        public User employee { get; set; }

        public Warehouse(int id, string name, string region, string adress, User employee)
        {
            this.id = id;
            this.name = name;
            this.region = region;
            this.adress = adress;
            this.employee = employee;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
