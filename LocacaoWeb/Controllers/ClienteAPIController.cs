using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        private readonly ClienteDAO _clienteDAO;

        public ClienteAPIController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Cliente> cliente = _clienteDAO.Listar();
            if (cliente.Count > 0)
            {
                return Ok(cliente);
            }
            return BadRequest(new { msg = "Lista de clientes vazia!" });
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Cliente cliente = _clienteDAO.buscarPorId(id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound(new { msg = "Cliente não encontrado!" });
        }

        [HttpPost]
        [Route("Cadastrar")]
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
                            return Created("", cliente);
                            /*return RedirectToAction("Index", "Cliente");*/
                        }
                        else
                        {
                            return Conflict(new { msg = "Já existe cliente cadastrado nesse CPF!" });
                            /*ModelState.AddModelError("", "Já existe cliente cadastrado nesse CPF!");*/
                        }
                    }
                    else
                    {
                        return Conflict(new { msg = "**Cpf inválido!**" });
                        /*ModelState.AddModelError("", "**Cpf inválido!**");*/
                    }
                }
                else
                {
                    return Conflict(new { msg = "**Menor de idade não pode ser cadastrado!**" });
                    /*ModelState.AddModelError("", "**Menor de idade não pode ser cadastrado!**");*/
                }
            }
            return BadRequest(ModelState);
        }
    }
}
