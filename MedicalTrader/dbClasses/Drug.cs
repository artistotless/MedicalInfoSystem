using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader
{
    public class Drug
    {

        public int id { get; set; }
        public string manufacturer { get; set; }
        public string nomenclature { get; set; }
        public string country { get; set; }
        public string expirationDate { get; set; }
        public int warehouse { get; set; }
        public int series { get; set; }
        public int price { get; set; }
        public int party { get; set; }
        public int quantity { get; set; }
        public int availableQuantity { get; set; }
        public string certNumber { get; set; }


        public Drug()
        {
        }

        public Drug(int id, string nomenclature, string manufacturer, string country, string expirationDate, int warehouse, int series, int quantity, int availableQuantity,string certNumber)
        {
            this.id = id;
            this.manufacturer = manufacturer;
            this.nomenclature = nomenclature;
            this.country = country;
            this.expirationDate = expirationDate;
            this.warehouse = warehouse;
            this.series = series;
            this.quantity = quantity;
            this.availableQuantity = availableQuantity;
            this.certNumber = certNumber;
        }
    }
}
