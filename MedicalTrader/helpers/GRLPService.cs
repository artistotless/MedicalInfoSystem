using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class GRLPService
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

                string url = Settings.GRLP_URL +"/grls.aspx";
                //Скачиваем html-разметку страницы
                string text = client.DownloadString(url);
                string regexTarget = @"GetGRLS.ashx\?FileGUID=\w*-\w*-\w*-\w*-\w*&UserReq=.......";
                //Создаём регулярное выражение (в нём будет указано, что мы хотим найти)
                Regex regex = new Regex(regexTarget, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                string remoteFileName = "";

                string localFileName = Settings.GRLP_PATH + Settings.GRLP_ZIP_NAME;
                MatchCollection matches = regex.Matches(text);



                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        remoteFileName = Settings.GRLP_URL + match.Value;

                }

                if (!Directory.Exists(Settings.GRLP_PATH))
                {

                    Directory.CreateDirectory(Settings.GRLP_PATH);
                }
                foreach (var item in Directory.GetFiles(Settings.GRLP_PATH))
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
