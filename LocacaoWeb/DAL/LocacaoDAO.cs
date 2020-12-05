using LocacaoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoWeb.DAL
{
    public class LocacaoDAO
    {
        private readonly Context _context;
        public LocacaoDAO(Context context) => _context = context;
        public void Cadastrar(Locacao locacao)
        {
            int dias = locacao.previsaoEntrega.Day - locacao.criadoEm.Day;
            locacao.totalLocacao = locacao.veiculo.valorDiaria * dias;
            locacao.veiculo.locado = true;

            _context.Locacoes.Add(locacao);
            _context.SaveChanges();
        }


        public void Alterar(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            _context.SaveChanges();
        }

        public List<Locacao> Listar() => _context.Locacoes.Include(x => x.cliente).Include(x => x.funcionario).Include(x => x.veiculo).ToList();
        public List<Locacao> ListarLocado() => _context.Locacoes.Include(x => x.cliente).Include(x => x.veiculo).Where(x => x.devolvido == false).ToList();
        public List<Locacao> ListarLocPorCli(string cpf) => _context.Locacoes.Where(x => x.cliente.cpf == cpf).ToList();
        public Veiculo BuscarVeiculo(string modelo) => _context.Veiculos.FirstOrDefault(x => x.modelo.Equals(modelo));
        public Locacao BuscarPorId(int id) => _context.Locacoes.Find(id);

    }
}
