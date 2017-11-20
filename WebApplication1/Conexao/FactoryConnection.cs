using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Conexao
{
    public class FactoryConnection
    {

        private static FactoryConnection factoryConnection;
        private List<ConnectionManager> manager;
        private FactoryConnection()
        {
            manager = new List<ConnectionManager>();
            factoryConnection = this;
        }

        public static FactoryConnection getInstance()
        {
            if (factoryConnection == null)
                return new FactoryConnection();
            return factoryConnection;
        }

        public ConnectionManager getConnection()
        {
            ConnectionManager connection = null;

            lock (manager)
            {
                ConnectionManager optional = manager.FirstOrDefault(x => !x.isUse());
                if (optional != null)
                {
                    connection = optional;
                    SqlCommand comando = new SqlCommand("SELECT 1", connection.getConnection());
                    comando.ExecuteNonQuery();
                    if (connection.getConnection().State == System.Data.ConnectionState.Closed)
                    {
                        manager.Remove(optional);
                        connection = null;
                    }
                    else
                    {
                        connection.lockK();
                    }
                }
            }
            if (connection == null) {
                SqlConnection conn = null;
                conn = new SqlConnection(DadosConexao.getStringConnection());
                conn.Open();
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    connection = new ConnectionManager(conn);
                    connection.lockK();
                    manager.Add(connection);
                }

            }

            return connection;
        }

    }


}