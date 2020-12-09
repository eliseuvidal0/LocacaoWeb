using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LocacaoWeb.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;
        public ClienteController(ClienteDAO clienteDAO) => _clienteDAO = clienteDAO;
        public IActionResult Index()
        {
            return View(_clienteDAO.Listar());
        }

        public IActionResult Listar() => View(_clienteDAO.Listar());

        [AllowAnonymous]
        public IActionResult Cadastrar() => View();
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (Validacao.CalcularIdade(cliente.nascimento) > 17)
                {
                    if (Validacao.ValidarCpf(cliente.cpf))
                    {
                        if (_clienteDAO.Cadastrar(cliente))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Já existe cliente cadastrado nesse CPF!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "**Cpf inválido!**");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "**Menor de idade não pode ser cadastrado!**");
                }
            }
            else
            {
                ModelState.AddModelError("", "**Preencha todos os campos!**");
            }
            return View(cliente);
        }
        public IActionResult Remover(int id)
        {
            _clienteDAO.Remover(id);
            return RedirectToAction("Index", "Cliente");
        }

        public IActionResult Editar(int id)
        {
            return View(_clienteDAO.buscarPorId(id));
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _clienteDAO.Editar(cliente);

            return RedirectToAction("Index", "Cliente");
        }
    }
}
