using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using N2_1BIM_LP1.DAO;
using N2_1BIM_LP1.Models;

namespace N2_1BIM_LP1.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index ()
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                var lista = dao.ListaJogos();
                return View(lista);
            }
            catch (Exception er)
            {
                return View("Error", new ErrorViewModel(er.Message));
            }
        }
        public IActionResult Create()
        {
            return View("Form");
        }
    }
}
