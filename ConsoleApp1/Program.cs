using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DAO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            CotacaoDAO dao = new CotacaoDAO();
            dao.get("PETR4");
            dao.get("LAME4");

        }
    }
}
