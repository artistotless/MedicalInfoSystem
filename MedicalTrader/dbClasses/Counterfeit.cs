using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
    class Counterfeit
    {
        public int id { get; set; }
        public int idDrud { get; set; }

        public Counterfeit(int idDrud)
        {
            this.idDrud = idDrud;
        }

        public Counterfeit()
        {
        }
    }
}
