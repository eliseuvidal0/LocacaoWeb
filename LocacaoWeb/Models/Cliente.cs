using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWeb.Models
{
    [Table("Clientes")]
    public class Cliente : Pessoa
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual DateTime nascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String cnh { get; set; }

    }
}
