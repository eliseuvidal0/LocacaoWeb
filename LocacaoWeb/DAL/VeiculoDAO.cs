using LocacaoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoWeb.DAL
{
    public class VeiculoDAO
    {
        private readonly Context _context;
        public VeiculoDAO(Context context) => _context = context;
        public bool Cadastrar(Veiculo veiculo)
        {
            if (BuscarPlaca(veiculo.placa) != null)
            {
                return false;
            }
            else
            {
                _context.Veiculos.Add(veiculo);
                _context.SaveChanges();
                return true;
            }
        }
        public void Remover(Veiculo veiculo)
        {
            _context.Database.ExecuteSqlRaw("ALTER TABLE Locacoes NOCHECK CONSTRAINT FK_Locacoes_veiculos_veiculoid");
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
        }

        public void Editar(Veiculo veiculo)
        {

            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }

        public Veiculo BuscarPorId(int id) => _context.Veiculos.Find(id);
        public List<Veiculo> Listar() => _context.Veiculos.ToList();
        public List<Veiculo> ListarDisponivel() => _context.Veiculos.Where(x => x.locado == false).ToList();
        public Veiculo BuscarPlaca(string placa) => _context.Veiculos.FirstOrDefault(x => x.placa.Equals(placa));

    }
}
