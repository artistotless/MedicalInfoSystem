using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalTrader
{

    class GrlsDrug
    {
        public int id { get; set; }
        public string certNumber { get; set; }
        public string regDate { get; set; }
        public string certEndDate { get; set; }
        public string certNullDate { get; set; }
        public string certOwner { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public string chemicalName { get; set; }
        public string releaseForms { get; set; }
        public string stageOfProduction { get; set; }
        public string consumerBarcodes { get; set; }
        public string normativeDocuments { get; set; }
        public string farmGroups { get; set; }

        public GrlsDrug()
        {
        }

        public GrlsDrug(int id, string certNumber, string regDate, string certEndDate, string certNullDate, string certOwner, string country, string name, string chemicalName, string releaseForms, string stageOfProduction, string consumerBarcodes, string normativeDocuments, string farmGroups)
        {
            this.id = id;
            this.certNumber = certNumber;
            this.regDate = regDate;
            this.certEndDate = certEndDate;
            this.certNullDate = certNullDate;
            this.certOwner = certOwner;
            this.country = country;
            this.name = name;
            this.chemicalName = chemicalName;
            this.releaseForms = releaseForms;
            this.stageOfProduction = stageOfProduction;
            this.consumerBarcodes = consumerBarcodes;
            this.normativeDocuments = normativeDocuments;
            this.farmGroups = farmGroups;
        }
    }
}
