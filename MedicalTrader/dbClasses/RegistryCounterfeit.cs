using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
    class RegistryCounterfeit
    {

        public int id { get; set; }
        public string name { get; set; }
        public string formRealease { get; set; }
        public string series { get; set; }
        public string manufacturer { get; set; }
        public string country { get; set; }
        public string scale { get; set; }
        public string documentUrl { get; set; }
        public string status { get; set; }

        public RegistryCounterfeit(int id, string name, string formRealease, string series, string manufacturer, string country, string scale, string documentUrl, string status)
        {
            this.id = id;
            this.name = name;
            this.formRealease = formRealease;
            this.series = series;
            this.manufacturer = manufacturer;
            this.country = country;
            this.scale = scale;
            this.documentUrl = documentUrl;
            this.status = status;
        }
    }
}
