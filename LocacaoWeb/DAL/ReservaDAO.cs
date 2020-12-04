using LocacaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.DAL
{
    public class ReservaDAO
    {
        private readonly Context _context;

        public ReservaDAO(Context context) => _context = context;

        public void Cadastrar(Reserva reserva)
        {

        }

        public List<Reserva> Listar() => _context.Reservas.ToList();
        public List<Reserva> ListarReservados() => _context.Reservas.Where(x => x.ativo == true).ToList();
    }
}
