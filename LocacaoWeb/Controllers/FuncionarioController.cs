using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioDAO _funcionarioDAO;

        public FuncionarioController(FuncionarioDAO funcionarioDAO) => _funcionarioDAO = funcionarioDAO;

        public IActionResult Index()
        {
            return View(_funcionarioDAO.Listar());
        }

        public IActionResult Cadastrar() => View();
        
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (_funcionarioDAO.Cadastrar(funcionario))
                {
                    return RedirectToAction("Index", "Funcionario");
                }
                ModelState.AddModelError("", "Já existe funcionário cadastrado nesse CPF!");
            }
            return View(funcionario);
        } 
    }
}
