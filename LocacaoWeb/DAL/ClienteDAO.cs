using LocacaoWeb.Models;
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
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return true;
        }

        public void Remover(int id)
        {
            _context.Clientes.Remove(buscarPorId(id));
            _context.SaveChanges();
        }

        public List<Cliente> Listar() => _context.Clientes.ToList();

        public Cliente buscarCpf(String cpf) => _context.Clientes.FirstOrDefault(x => x.cpf.Equals(cpf));

        public Cliente buscarPorId(int id) => _context.Clientes.Find(id);
    }
}
