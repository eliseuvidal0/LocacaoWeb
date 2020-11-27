using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        public ClienteController(ClienteDAO clienteDAO) => _clienteDAO = clienteDAO;
        public IActionResult Index()
        {
            return View(_clienteDAO.Listar());
        }

        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (_clienteDAO.Cadastrar(cliente))
                {
                    return RedirectToAction("Index", "Cliente");
                }
                ModelState.AddModelError("", "Já existe cliente cadastrado nesse CPF!");
            }
            return View(cliente);
        }
    }
}
