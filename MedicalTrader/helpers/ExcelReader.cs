using ExcelDataReader;

using System.Collections.Generic;
using System.Data;
using System.IO;

using System.Threading.Tasks;


namespace MedicalTrader.helpers
{
    class RowData
    {
        public List<string> listData = new List<string>();
        public int row;

        public RowData(int[] selectedColumns, int row, DataRowCollection rowCollection)
        {
            this.row = row;
            foreach (var column in selectedColumns)
            {
                this.listData.Add(rowCollection[row][column].ToString());
            }
        }
    }
    class ExcelReader
    {
        DataTable table;
        List<RowData> itemList;
        int[] selectedRows;

        int offsetRow = 0;
        int rowsCompleteCount = 1;
        public async Task<List<RowData>> ExcelToSqlAsync(string excelFile, int idTable, int offsetRow, params int[] selectedRows)
        {
            this.selectedRows = selectedRows;
            return await Task.Run(() => ExcelToSql(excelFile, idTable, offsetRow));

        }

        private List<RowData> ExcelToSql(string excelFile, int idTable, int offsetRow) // 0 6
        {
            this.offsetRow = offsetRow;

            BackGroundEvents.ShowLoading("Обновление локальной БД...");
            using (var stream = File.Open(excelFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    table = result.Tables[idTable];
                    BackGroundEvents.HideLoading();
                    int i = 0;
                    itemList = new List<RowData>(table.Rows.Count);

                    for (i = 0; i < table.Rows.Count - offsetRow; i++)
                    {
                        itemList.Add(null);
                    }


                    Parallel.For(offsetRow, table.Rows.Count, CollectToArray);

                    BackGroundEvents.HideLoading();
                    return itemList;


                }
            }


        }

        public void CollectToArray(int i)
        {


            BackGroundEvents.ShowLoading(string.Format("Обновление локальной БД...({0}/{1})", rowsCompleteCount.ToString(), table.Rows.Count.ToString()));
            rowsCompleteCount++;
            itemList[i - offsetRow] = new RowData(selectedRows, i, table.Rows);

            Task.Delay(10);


        }
    }
}
