using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.DAL
{
    public class FuncionarioDAO
    {
        private readonly Context _context;
        public FuncionarioDAO(Context context) => _context = context;

        public bool Cadastrar(Funcionario funcionario)
        {
            if (buscarCpf(funcionario.cpf) != null)
            {
                return false;
            }

            funcionario.cpf = Validacao.Formatar(funcionario.cpf);

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return true;
        }

        public void Remover(int id)
        {
            _context.Funcionarios.Remove(buscarPorId(id));
            _context.SaveChanges();
       }

        public List<Funcionario> Listar() => _context.Funcionarios.ToList();

        public Funcionario buscarCpf(String cpf) => _context.Funcionarios.FirstOrDefault(x => x.cpf.Equals(cpf));

        public Funcionario buscarPorId(int id) => _context.Funcionarios.Find(id);
    }
}
