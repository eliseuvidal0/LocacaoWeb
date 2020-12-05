using LocacaoWeb.Models;
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

        public List<Reserva> Listar() => _context.Reservas.ToList();
        public List<Reserva> ListarReservados() => _context.Reservas.Where(x => x.ativo == true).ToList();
    }
}
