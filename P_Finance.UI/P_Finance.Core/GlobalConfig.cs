﻿using System.Configuration;
using P_Finance.Core.DataAccess;

namespace P_Finance.Core
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
