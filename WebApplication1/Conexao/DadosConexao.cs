using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Conexao
{
    public class DadosConexao
    {
        private static String Servidor { get; } = "tcp:esiacoesusp.database.windows.net";
        private static String Porta { get; } = "1433";
        private static String Banco { get; } = "esiacoesusp";
        private static String Usuario { get; } = "lucas";
        private static String Senha { get; } = "Gl804hp8@@";

        public static String getStringConnection()
        {
            return "Server=" + Servidor + "," + Porta + ";Initial Catalog=" + Banco + ";Persist Security Info=False;"+ 
                   "User ID=" + Usuario + ";Password=" + Senha + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

    }
}