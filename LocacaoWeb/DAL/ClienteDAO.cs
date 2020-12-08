using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.DAL
{
    public class ClienteDAO
    {
        private readonly Context _context;
        public ClienteDAO(Context context) => _context = context;

        public bool Cadastrar(Cliente cliente)
        {
            if (buscarCpf(cliente.cpf) != null)
            {
                return false;
            }

            cliente.cpf = Validacao.Formatar(cliente.cpf);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return true;
        }

        public void Remover(int id)
        {
            _context.Database.ExecuteSqlRaw("ALTER TABLE Locacoes NOCHECK CONSTRAINT FK_Locacoes_clientes_clienteid");
            _context.Clientes.Remove(buscarPorId(id));
            _context.SaveChanges();
        }

        public void Editar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> Listar() => _context.Clientes.ToList();

        public Cliente buscarCpf(String cpf) => _context.Clientes.FirstOrDefault(x => x.cpf.Equals(cpf));

        public Cliente buscarPorId(int id) => _context.Clientes.Find(id);

        /*public bool BuscarPorCpf(String cpf)
        {
            var x = _context.Clientes.FirstOrDefault(x => x.cpf == cpf);
            if (x != null)
            {
                return false;
            }
            return true;
        }*/

        public List<Cliente> BuscarPorCpf(string cpf) => _context.Clientes.Where(x => x.cpf.Contains(cpf)).ToList();
        

    }
}
