

namespace MedicalTrader
{
    static class DBConnector
    {
        private static DBWrapper db;

        public static DBWrapper Db()
        {
            if (db == null) { db = new DBWrapper(); }

            return db;
        }


    }
}
