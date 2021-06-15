using System.Collections.Generic;

namespace MedicalTrader
{
    public class DrugOffer
    {
        public List<Drug> drugArray;
        public string companyName;

        public DrugOffer(List<Drug> drugArray, string companyName)
        {
            this.drugArray = drugArray;
            this.companyName = companyName;
        }
    }
}