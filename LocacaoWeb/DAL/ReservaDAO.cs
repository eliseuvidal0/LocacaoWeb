using LocacaoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoWeb.DAL
{
    public class ReservaDAO
    {
        private readonly Context _context;

        public ReservaDAO(Context context) => _context = context;

        public void Cadastrar(Reserva reserva)
        {
            reserva.veiculo.reservado = reserva.cliente.cpf;

            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public void Editar(Reserva reserva)
        {

            _context.Reservas.Update(reserva);
            _context.SaveChanges();
        }

        public List<Reserva> Listar() => _context.Reservas.Include(x => x.cliente).Include(x => x.veiculo).ToList();
        public List<Reserva> ListarReservados() => _context.Reservas.Include(x => x.cliente).Include(x => x.veiculo).Where(x => x.ativo == true).ToList();
    }
}
