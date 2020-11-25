using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWeb.Models
{
    [Table("Clientes")]
    public class Cliente : Pessoa
    {
        public virtual DateTime nascimento { get; set; }
        public virtual String telefone { get; set; }
        public virtual String cnh { get; set; }

    }
}
