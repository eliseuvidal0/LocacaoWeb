using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocacaoWeb.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaDAO _reservaDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly VeiculoDAO _veiculoDAO;

        public ReservaController(ReservaDAO reservaDAO, ClienteDAO clienteDAO, VeiculoDAO veiculoDAO)
        {
            _reservaDAO = reservaDAO;
            _clienteDAO = clienteDAO;
            _veiculoDAO = veiculoDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.Listar(), "id", "modelo");

            return View();
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.Listar(), "id", "modelo");

            return View();
        }
    }
}
