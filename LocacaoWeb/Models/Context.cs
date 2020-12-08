using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocacaoWeb.Models
{
    public class Context : IdentityDbContext<Gerente>
    {
        public Context(DbContextOptions options) : base (options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<GerenteView> Gerentes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
