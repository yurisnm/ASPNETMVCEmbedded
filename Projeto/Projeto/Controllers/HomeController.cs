using Projeto.Models;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        //Criando o meu cronograma que sera impresso na view
        Cronograma cronograma = new Cronograma();

        public ActionResult Index()
        {
            return View(cronograma);
        }

        public ActionResult HorariosView()
        {

            return View(cronograma);
        }

        public ActionResult HorarioIndividualView()
        {
            return View(cronograma);
        }

        [HttpPost]
        public ActionResult HorarioIndividualView(Cronograma model)
        {
            
            return View(model);

        }

        public ActionResult AlunosHorarioView()
        {
            return View(cronograma);
        }

        [HttpPost]
        public ActionResult AlunosHorarioView(Cronograma model)
        {
            return View(model);
        }

        public ActionResult AdicionaAlunoView()
        {
            return View(cronograma);
        }

        [HttpPost]
        public ActionResult AdicionaAlunoView(Cronograma model)
        {
            return View(model);
        }


    }
}