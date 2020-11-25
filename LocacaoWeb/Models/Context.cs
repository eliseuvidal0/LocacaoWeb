using Microsoft.EntityFrameworkCore;
using System;

namespace LocacaoWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base (options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
    }
}
