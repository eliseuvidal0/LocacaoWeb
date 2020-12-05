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
            //if (ModelState.IsValid)
            //{
            locacao.cliente = _clienteDAO.buscarPorId(locacao.cliID);
            locacao.funcionario = _funcionarioDAO.buscarPorId(locacao.funID);
            locacao.veiculo = _veiculoDAO.BuscarPorId(locacao.vecID);
            if (Validacao.ValidarCatCnh(locacao))
            {
                if (locacao.veiculo.reservado == locacao.cliente.cpf || locacao.veiculo.reservado == "0")
                {
                    if (_locacaoDAO.Cadastrar(locacao))
                    {
                        return RedirectToAction("Index", "Locacao");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Veículo LOCADO!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Veículo RESERVADO!");
                }
            }
            else
            {
                ModelState.AddModelError("", "CNH INVÁLIDA!");
            }
            //}

            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Funcionario = new SelectList(_funcionarioDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.Listar(), "id", "modelo");

            return View(locacao);
        }
    }
}
