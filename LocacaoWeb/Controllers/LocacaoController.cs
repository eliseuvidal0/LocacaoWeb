﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocacaoWeb.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly LocacaoDAO _locacaoDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly FuncionarioDAO _funcionarioDAO;
        private readonly VeiculoDAO _veiculoDAO;

        public LocacaoController(LocacaoDAO locacaoDAO, ClienteDAO clienteDAO, FuncionarioDAO funcionarioDAO, VeiculoDAO veiculoDAO)
        {
            _locacaoDAO = locacaoDAO;
            _clienteDAO = clienteDAO;
            _funcionarioDAO = funcionarioDAO;
            _veiculoDAO = veiculoDAO;
        }
        public IActionResult Index()
        {
            return View(_locacaoDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Funcionario = new SelectList(_funcionarioDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.Listar(), "id", "modelo");

            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Locacao locacao)
        {

            if (ModelState.IsValid)
            {
                if (Validacao.ValidarCatCnh(locacao))
                {
                    if (_locacaoDAO.Cadastrar(locacao))
                    {
                        return RedirectToAction("Index", "Locacao");
                    }
                    ModelState.AddModelError("", "Veículo LOCADO!");
                } else
                {
                    ModelState.AddModelError("", "CNH INVÁLIDA!");
                }
            }
            return View(locacao);
        }
    }
}
