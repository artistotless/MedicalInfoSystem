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
        public string address { get; set; }
        public int employee { get; set; }

        public Warehouse(int id, string name, string region, string adress, int employee)
        {
            this.id = id;
            this.name = name;
            this.region = region;
            this.address = adress;
            this.employee = employee;
        }

        public Warehouse()
        {
        }

        public override string ToString()
        {
            return name;
        }
    }
}
