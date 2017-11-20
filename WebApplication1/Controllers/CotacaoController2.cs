using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CotacaoController2 : ApiController
    {
        // GET: Cotacao
        public Cotacao Get(String ativo)
        {

            CotacaoDAO dao = new CotacaoDAO();
            Cotacao cotacao = dao.get(ativo);
            return cotacao;

        }
    }
}