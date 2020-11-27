using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly LocacaoDAO _locacaoDAO;

        public LocacaoController(LocacaoDAO locacaoDAO) => _locacaoDAO = locacaoDAO;
        public IActionResult Index()
        {
            return View(_locacaoDAO.Listar());
        }

        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                if (_locacaoDAO.Cadastrar(locacao))
                {
                    return RedirectToAction("Index", "Locacao");
                }
                ModelState.AddModelError("", "Já existe locacao cadastrada com os dados informados!");
            }
            return View(locacao);
        }
    }
}
