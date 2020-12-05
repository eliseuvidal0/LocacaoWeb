﻿using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
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
                if (Validacao.ValidarCpf(funcionario.cpf))
                {
                    if (_funcionarioDAO.Cadastrar(funcionario))
                    {
                        return RedirectToAction("Index", "Funcionario");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Funcionário já existe!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "**Cpf inválido!**");
                }

            }
            return View(funcionario);
        }

        public IActionResult Remover(int id)
        {
            _funcionarioDAO.Remover(id);
            return RedirectToAction("Index", "Funcionario");
        }

        public IActionResult Editar(int id)
        {
            return View(_funcionarioDAO.buscarPorId(id));
        }
        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            _funcionarioDAO.Editar(funcionario);

            return RedirectToAction("Index", "Funcionario");
        }
    }
}
