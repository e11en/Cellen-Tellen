using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finan
{
    public class ConnectionModel
    {
        public SqlConnection connection;

        private string ipAddress = "192.168.178.78\\SQLEXPRESS";
        private string databaseName = "CellenTellen";
        private string user = "SQLUser02";
        private string password = "Cellentellen@2013";
        private string timeout = "3";

        public ConnectionModel()
        {
            connection = new SqlConnection
                (string.Format("server={0}; Database={1}; User={2}; Password={3};connection timeout={4}"
                , ipAddress, databaseName, user, password, timeout));
        }
    }
}
