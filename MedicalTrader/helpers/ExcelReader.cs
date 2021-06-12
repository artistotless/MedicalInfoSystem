﻿using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalTrader.helpers
{
    class ExcelReader
    {
        DataTable table;
        List<GrlsDrug> grlpList;
        int rowsCompleteCount = 1;
        public async Task<List<GrlsDrug>> ExcelToSqlAsync(string excelFile)
        {
            return await Task.Run(() => ExcelToSql(excelFile));

        }

        private List<GrlsDrug> ExcelToSql(string excelFile)
        {
            List<GrlsDrug> list = new List<GrlsDrug>();
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

                    table = result.Tables[0];
                    BackGroundEvents.HideLoading();
                    int i = 0;
                    grlpList = new List<GrlsDrug>(table.Rows.Count);

                    for (i = 0; i < table.Rows.Count - 6; i++)
                    {
                        grlpList.Add(null);
                    }


                    Parallel.For(6, table.Rows.Count, CollectToArray);
                    
                    BackGroundEvents.HideLoading();
                    return grlpList;


                }
            }


        }

        public void CollectToArray(int i)
        {


            BackGroundEvents.ShowLoading(string.Format("Обновление локальной БД...({0}/{1})", rowsCompleteCount.ToString(), table.Rows.Count.ToString()));
            rowsCompleteCount++;
            grlpList[i - 6] = new GrlsDrug(
                    0,
                    table.Rows[i][2].ToString(),
                    table.Rows[i][3].ToString(),
                    table.Rows[i][4].ToString(),
                    table.Rows[i][5].ToString(),
                    table.Rows[i][6].ToString(),
                    table.Rows[i][7].ToString(),
                    table.Rows[i][8].ToString(),
                    table.Rows[i][9].ToString(),
                    table.Rows[i][10].ToString(),
                    table.Rows[i][11].ToString(),
                    table.Rows[i][13].ToString(),
                    table.Rows[i][14].ToString(),
                    table.Rows[i][15].ToString()



                    );
            Task.Delay(10);


        }
    }
}
