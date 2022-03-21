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
                var lista = dao.ListaCurriculos();
                return View(lista);
            }
            catch (Exception er)
            {
                return View("Error", new ErrorViewModel(er.Message));
            }

        }
        public IActionResult FormCadastro ()
        {
            return View();
        }
        public IActionResult Create ()
        {
            return View("Form");
        }
        public IActionResult Salvar (CurriculoViewModel cv)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO ();
                dao.Inserir(cv);
                return RedirectToAction("FormCadastro");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
    }
}
