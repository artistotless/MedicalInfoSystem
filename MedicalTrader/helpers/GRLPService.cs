
using System.IO;

using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class GRLSService
    {
     
        public async Task<string> DownloadGRLPAsync()
        {

            return await Task.Run(() => DownloadGRLP());
        }
        private string DownloadGRLP()
        {

            using (WebClient client = new WebClient() { Encoding = Encoding.UTF8 })
            {
                BackGroundEvents.ShowLoading("Загрузка номенклатуры с ГРЛП (grls.rosminzdrav.ru)...");

                if (File.Exists(Settings.DB_PATH + Settings.GRLP_ZIP_NAME))
                {
                    return Settings.DB_PATH + Settings.GRLP_ZIP_NAME;
                }

                string url = Settings.GRLP_URL +"/grls.aspx";
                //Скачиваем html-разметку страницы
                string text = client.DownloadString(url);
                string regexTarget = @"GetGRLS.ashx\?FileGUID=\w*-\w*-\w*-\w*-\w*&UserReq=.......";
                //Создаём регулярное выражение (в нём будет указано, что мы хотим найти)
                Regex regex = new Regex(regexTarget, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                string remoteFileName = "";

                string localFileName = Settings.DB_PATH + Settings.GRLP_ZIP_NAME;
                MatchCollection matches = regex.Matches(text);



                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        remoteFileName = Settings.GRLP_URL + match.Value;

                }

                if (!Directory.Exists(Settings.DB_PATH))
                {

                    Directory.CreateDirectory(Settings.DB_PATH);
                }
                foreach (var item in Directory.GetFiles(Settings.DB_PATH))
                {
                    File.Delete(item);
                }

                client.DownloadFile(remoteFileName, localFileName);

                BackGroundEvents.HideLoading();
                return localFileName;

            }
        }

    }
}
