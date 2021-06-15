using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class RosZdravNadzor
    {


        public async Task<BuyerLicense> GetLicenceAsync(string inn)
        {
            BackGroundEvents.ShowLoading("Проверяется наличие лицензии...");

            HttpClient httpClient = new HttpClient();
            string request = RequestParameters.GetUrl(inn, RequestType.License);
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            //JObject jObject = JObject.Parse(responseBody);

            BuyerLicense result = JsonConvert.DeserializeObject<BuyerLicense>(responseBody);

            BackGroundEvents.HideLoading();

            return result;

        }





        public async Task<string> GetCounterfeitAsync(int status)
        {
            string url = RequestParameters.GetUrl(status, RequestType.Counterfeit);
            string localFileName = Settings.COUNTERFEIT_NAME + status.ToString() + ".xls";
            BackGroundEvents.ShowLoading("Загрузка данных из реестра забракованных ЛС...");

            using (WebClient client = new WebClient() { Encoding = Encoding.UTF8 })
            {
                await client.DownloadFileTaskAsync(new Uri(url), localFileName);

                BackGroundEvents.HideLoading();
                return localFileName;

            }

        }



    }
}
