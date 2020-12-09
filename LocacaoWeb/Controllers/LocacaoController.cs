using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace LocacaoWeb.Controllers
{
    [Authorize]
    public class LocacaoController : Controller
    {
        private readonly LocacaoDAO _locacaoDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly FuncionarioDAO _funcionarioDAO;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly ReservaDAO _reservaDAO;

        public LocacaoController(LocacaoDAO locacaoDAO, ClienteDAO clienteDAO, FuncionarioDAO funcionarioDAO, VeiculoDAO veiculoDAO, ReservaDAO reservaDAO)
        {
            _locacaoDAO = locacaoDAO;
            _clienteDAO = clienteDAO;
            _funcionarioDAO = funcionarioDAO;
            _veiculoDAO = veiculoDAO;
            _reservaDAO = reservaDAO;
        }
        public IActionResult Index()
        {
            return View(_locacaoDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Funcionario = new SelectList(_funcionarioDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.ListarDisponivel(), "id", "modelo");

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
                Veiculo aux = _veiculoDAO.BuscarPorId(locacao.vecID);

                
                    if (locacao.veiculo.reservado == locacao.cliente.cpf || locacao.veiculo.reservado == "0")
                    {
                        aux.reservado = "0";
                        _veiculoDAO.Editar(aux);
                        RemoverReserva(aux);

                        _locacaoDAO.Cadastrar(locacao);
                        return RedirectToAction("Index", "Locacao");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Veículo RESERVADO!");
                    }
                
            //}

            ViewBag.Cliente = new SelectList(_clienteDAO.Listar(), "id", "nome");
            ViewBag.Funcionario = new SelectList(_funcionarioDAO.Listar(), "id", "nome");
            ViewBag.Veiculo = new SelectList(_veiculoDAO.Listar(), "id", "modelo");

            return View(locacao);
        }

        public IActionResult Devolucao()
        {
            return View(_locacaoDAO.ListarLocado());
        }

        public IActionResult Devolver(int id)
        {
            Locacao loc = _locacaoDAO.BuscarPorId(id);

            loc.dataEntrega = DateTime.Now;
            loc.devolvido = true;
            Veiculo vec = _veiculoDAO.BuscarPorId(loc.vecID);

            vec.locado = false;
            _veiculoDAO.Editar(vec);


            if (loc.dataEntrega.Month > loc.previsaoEntrega.Month)
            {
                int dias = (loc.dataEntrega - loc.previsaoEntrega).Days;
                loc.custoVariavel = loc.veiculo.valorDiaria * dias;
                loc.totalLocacao += loc.custoVariavel;

                _locacaoDAO.Alterar(loc);
                /*MessageBox.Show($"Veículo entregue! Pelo atraso de {dias} dias, " +
                    $"houve a cobrança extra no valor de R$ {lo.custoVariavel}", "Locação - WPF",
                                        MessageBoxButton.OK, MessageBoxImage.Information);*/
            }
            else if (loc.dataEntrega.Day > loc.previsaoEntrega.Day)
            {
                int atraso = loc.dataEntrega.Day - loc.previsaoEntrega.Day;
                loc.custoVariavel = loc.veiculo.valorDiaria * atraso;
                loc.totalLocacao += loc.custoVariavel;

                _locacaoDAO.Alterar(loc);
                /*MessageBox.Show($"Veículo entregue! Pelo atraso de {atraso} dias, " +
                    $"houve a cobrança extra no valor de R$ {lo.custoVariavel}", "Locação - WPF",
                                        MessageBoxButton.OK, MessageBoxImage.Information);*/
            }
            else if (loc.dataEntrega.Day < loc.previsaoEntrega.Day)
            {


                int dias = loc.previsaoEntrega.Day - loc.dataEntrega.Day;
                loc.custoVariavel = loc.veiculo.valorDiaria * dias;
                loc.totalLocacao -= loc.custoVariavel;

                if (loc.totalLocacao == 0)
                {
                    loc.custoVariavel -= loc.veiculo.valorDiaria;
                    loc.totalLocacao = loc.veiculo.valorDiaria;

                    _locacaoDAO.Alterar(loc);
                    /*MessageBox.Show($"Veículo entregue! Pela entrega antecipada de {dias} dias, " +
                        $"houve o desconto de R$ {lo.custoVariavel}", "Locação - WPF",
                                            MessageBoxButton.OK, MessageBoxImage.Information);*/
                }
                else
                {
                    _locacaoDAO.Alterar(loc);
                    //MessageBox.Show($"Veículo entregue! Pela entrega antecipada de {dias} dias, " +
                    //    $"houve o desconto de R$ {lo.custoVariavel}", "Locação - WPF",
                    //                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                _locacaoDAO.Alterar(loc);
                //MessageBox.Show($"Veículo entregue na data esperada!", "Locação - WPF",
                //                        MessageBoxButton.OK, MessageBoxImage.Information);
            }


            return RedirectToAction("Devolucao", "Locacao");
        }

        private void RemoverReserva(Veiculo veiculo)
        {
            foreach (Reserva re in _reservaDAO.ListarReservados())
            {
                if(veiculo.id == re.vecID)
                {
                    re.ativo = false;
                    _reservaDAO.Editar(re);
                }
            }
        }
    }
}
