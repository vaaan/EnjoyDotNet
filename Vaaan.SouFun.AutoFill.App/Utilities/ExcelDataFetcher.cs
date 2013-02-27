using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Vaaan.SouFun.AutoFill.App.Utilities
{
    class ExcelDataFetcher
    {
        public static DataTable Fetch(string fileName, string sheetName)
        {
            return Fetch(fileName, sheetName, true);
        }

        public static DataTable Fetch(string fileName, string sheetName, bool useHeadRow)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = connection.CreateCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable excelTable = new DataTable();
            connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1};IMEX=1\"", fileName, useHeadRow ? "yes" : "no");
            command.CommandText = string.Format("SELECT * FROM [{0}$]", sheetName);
            adapter.Fill(excelTable);
            return excelTable;
        }
    }
}
