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
        public virtual String cpf { get; set; }
        public virtual String nome { get; set; }
        public virtual String email { get; set; }
        public virtual DateTime criadoEm { get; set; }
    }
}
