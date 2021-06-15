using System;


namespace MedicalTrader.helpers
{
    class Settings
    {
        public static string DATA_PATH = Environment.CurrentDirectory + @"\data\";
        public static string DB_PATH = DATA_PATH + @"db\";
        public static string GRLP_URL = "http://grls.rosminzdrav.ru/";
        public static string GRLP_ZIP_NAME = "grlp.zip";
        public static string COUNTERFEIT_NAME = "counterfeits";

    }
}
