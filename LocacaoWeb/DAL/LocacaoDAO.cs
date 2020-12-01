using LocacaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.DAL
{
    public class LocacaoDAO
    {
        private readonly Context _context;
        public LocacaoDAO(Context context) => _context = context;
        public bool Cadastrar(Locacao locacao)
        {
            if (locacao.veiculo.locado)
            {
                return false;
            }
            else
            {
                int dias = locacao.previsaoEntrega.Day - locacao.criadoEm.Day;
                locacao.totalLocacao = locacao.veiculo.valorDiaria * dias;
                locacao.veiculo.locado = true;

                _context.Locacoes.Add(locacao);
                _context.SaveChanges();
                locacao.veiculo.locado = true;
                return true;
            }

        }
        public void Alterar(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            _context.SaveChanges();
        }

        public bool ValidarCatCnh(Locacao locacao)
        {
            if (locacao.veiculo.tipo == "Carro" && locacao.cliente.cnh == "A")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Caminhão" && locacao.cliente.cnh == "B")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Caminhão" && locacao.cliente.cnh == "A")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Caminhão" && locacao.cliente.cnh == "AB")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Moto" && locacao.cliente.cnh == "B")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Moto" && locacao.cliente.cnh == "C")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Moto" && locacao.cliente.cnh == "D")
            {
                return false;
            }
            else if (locacao.veiculo.tipo == "Moto" && locacao.cliente.cnh == "E")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Locacao> Listar() => _context.Locacoes.ToList();
        public List<Locacao> ListarLocado() => _context.Locacoes.Where(x => x.devolvido == false).ToList();
        public List<Locacao> ListarLocPorCli(string cpf) => _context.Locacoes.Where(x => x.cliente.cpf == cpf).ToList();

        public Veiculo BuscarVeiculo(string modelo) => _context.Veiculos.FirstOrDefault(x => x.modelo.Equals(modelo));
        public Locacao BuscarPorId(int id) => _context.Locacoes.Find(id);
    }
}
