using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using Microsoft.AspNetCore.Authorization;
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
            ViewBag.Veiculo = new SelectList(_veiculoDAO.ListarDisponivel(), "id", "modelo");

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.cliente = _clienteDAO.buscarPorId(reserva.cliID);
                reserva.veiculo = _veiculoDAO.BuscarPorId(reserva.vecID);

                _reservaDAO.Cadastrar(reserva);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Por favor, Preencha todos os campos!");
            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.Listar(), "id", "modelo");
            return View(reserva);
        }

        [Authorize]
        public IActionResult Reservados()
        {
            return View(_reservaDAO.ListarReservados());
        }
    }
}
