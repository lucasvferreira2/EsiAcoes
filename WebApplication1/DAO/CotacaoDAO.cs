using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Conexao;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class CotacaoDAO
    {

        public Cotacao get(String ativo)
        {

            using (ConnectionManager manager = FactoryConnection.getInstance().getConnection())
            {
                return get(manager.getConnection(), ativo);
            }

        }

        private Cotacao get(SqlConnection conn, String ativo)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT * FROM Cotacao WHERE SIGLA = '" + ativo + "'");

            using (SqlCommand command = new SqlCommand(str.ToString(), conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
/*                        Cotacao cotacao = new Cotacao()
                        {
                            Valor = reader.GetDecimal(1),
                            Sigla = reader.GetString(0)
                        };
                        Console.WriteLine("Acao " + ativo + " VALOR " + reader.GetDecimal(1));
                        return cotacao;
                        */
                    }
                }

            }

            return null;
        }

        

    }
}