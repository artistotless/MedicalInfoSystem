using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class Settings
    {
        public static string DATA_PATH = Environment.CurrentDirectory + @"\data\";
        public static string GRLP_PATH = DATA_PATH + @"db\";
        public static string GRLP_URL = "http://grls.rosminzdrav.ru/";
        public static string GRLP_ZIP_NAME = "grlp.zip";




    }
}
