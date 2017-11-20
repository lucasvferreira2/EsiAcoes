using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Conexao
{
    public class ConnectionManager: IDisposable
    {
        private SqlConnection connection;
        private bool use;

        public ConnectionManager(SqlConnection connection)
        {
            this.connection = connection;
            use = false;
        }
        public SqlConnection getConnection()
        {
            return connection;
        }
        public void setConnection(SqlConnection connection)
        {
            this.connection = connection;
        }
        public bool isUse()
        {
            return use;
        }

        public void lockK () {
            lock (this) {
                use = true;
            }
        }

        private void deslock()
        {
            lock (this) {
                use = false;
            }
        }

        public void Dispose()
        {
            deslock();
        }
    }
}