using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTrader.helpers
{
    class ExcelReader
    {
        public async Task ExcelToSqlAsync(string excelFile)
        {
            await Task.Run(() => ExcelToSql(excelFile));

        }

        private void ExcelToSql(string excelFile)
        {

            BackGroundEvents.ShowLoading("Обновление локальной БД...");
            using (var stream = File.Open(excelFile, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:


                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();
                    var tableData = "";
                    var table = result.Tables[0];

                    for (var i = 5; i < table.Rows.Count; i++)
                    {
                        for (var j = 2; j < table.Columns.Count; j++)
                        {
                            tableData += table.Rows[i][j].ToString() + "\n";
                        }
                    }
                    //TODO: Обновление БД ГРЛП
                    BackGroundEvents.HideLoading();
                    //MessageBox.Show(tableData);
                    
                }
            }


        }
    }
}
