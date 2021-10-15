using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hopp
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "192.168.70.5";
            int port = 3306;
            string database = "Hopp";
            string username = "appuser";
            string password = "appuser";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
