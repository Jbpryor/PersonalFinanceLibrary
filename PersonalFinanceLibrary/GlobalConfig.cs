using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceLibrary.DataAccess;

namespace PersonalFinanceLibrary
{
    public static class GlobalConfig        
    {
        public const string ExcelFile = "Financials 1.1.xlsx";
        public static IDataConnection? Connection { get; private set; }

        public static void CreateConnection()
        {
            SqlConnector sql = new();
            Connection = sql;
        }

        public static string ConnectorString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
