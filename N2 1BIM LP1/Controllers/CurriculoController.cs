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
                if (lista == null) /* se o banco estiver vazio, direciona para a tela de cadastro */
                    return View("FormCadastro");
                return View(lista); /* senão retorna a lista de CV */
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
                CurriculoDAO dao = new CurriculoDAO();
                dao.Inserir(cv);
                /* VerificaCPF(cv); */ /* comentado para demonstração ficar mais simples */
                return RedirectToAction("FormCadastro");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
        private void VerificaCPF (CurriculoViewModel cv)
        {
            if (!int.TryParse (cv.Cpf, out int result))
                throw new Exception("Insira apenas dígitos.");
            else
            if (cv.Cpf.Length != 11)
                throw new Exception("O número do CPF deve ter 11 dígitos.");
        }
        public IActionResult Alterar (string valorCPF)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                var lista = dao.ListaCurriculos();

                CurriculoViewModel umItem = new CurriculoViewModel();
                foreach (CurriculoViewModel item in lista)
                {
                    if (item.Cpf == valorCPF)
                    {
                        umItem = item;
                        break;
                    }
                }

                return View("FormAlterar", umItem);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
        public IActionResult ConfirmarAlteracao(CurriculoViewModel cv)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Alterar(cv);
                return RedirectToAction("FormCadastro");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
        public IActionResult Excluir (string valorCPF)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Excluir(valorCPF);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
    }
}
