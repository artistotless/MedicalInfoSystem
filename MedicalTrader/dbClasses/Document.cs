using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalTrader
{
    class Document
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string bytes { get; set; }
        public string date { get; set; }
        public string descr { get; set; }

        public Document(int id, string name, string type, string bytes, string date, string descr)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.bytes = bytes;
            this.date = date;
            this.descr = descr;
        }

        public Document()
        {
        }
    }
}
