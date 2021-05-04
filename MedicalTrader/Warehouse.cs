using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
    public class Warehouse
    {
        public string name;

        public Warehouse(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
