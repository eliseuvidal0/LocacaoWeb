using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly VeiculoDAO _veiculoDAO;

        public VeiculoController(VeiculoDAO veiculoDAO) => _veiculoDAO = veiculoDAO;
        public IActionResult Index()
        {
            return View(_veiculoDAO.Listar());
        }
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                if (Validacao.ValidarPlaca(veiculo.placa)) {
                    if (_veiculoDAO.Cadastrar(veiculo))
                    {
                        return RedirectToAction("Index", "Veiculo");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Já existe veiculo cadastrado nessa PLACA!");
                    }
                    
                } else
                {

                    ModelState.AddModelError("", "PLACA INVÁLIDA!");
                }
            }
            return View(veiculo);
        }
    }
}
