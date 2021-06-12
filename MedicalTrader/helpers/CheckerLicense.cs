using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class CheckerLicense
    {
        private string urlService = "https://roszdravnadzor.gov.ru/ajax/services/licenses?";

        public async Task<BuyerLicense> CheckLicenceAsync(string inn)
        {
            BackGroundEvents.ShowLoading("Проверяется наличие лицензии...");

            HttpClient httpClient = new HttpClient();
            string request = urlService + LicenceApiParameters.Get(inn);
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            //JObject jObject = JObject.Parse(responseBody);

            BuyerLicense result = JsonConvert.DeserializeObject<BuyerLicense>(responseBody);
       
            BackGroundEvents.HideLoading();

            return  result;
            
        }

    }
}
