using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Criando o meu cronograma que sera impresso na view
            Cronograma cronograma = new Cronograma();

            return View(cronograma);
        }

        public ActionResult HorariosView()
        {
            return View();
        }
    }
}