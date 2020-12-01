using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoWeb.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            this.criadoEm = DateTime.Now;
        }
        [Key]
        public virtual int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String email { get; set; }
        public virtual DateTime criadoEm { get; set; }
    }
}
