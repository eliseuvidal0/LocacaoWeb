using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWeb.Models
{
    [Table("veiculos")]
    public class Veiculo
    {

        [Key]
        public virtual int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string placa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string cor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual double valorDiaria { get; set; }
        public virtual bool locado { get; set; }
        public virtual string reservado { get; set; }
        public virtual DateTime criadoEm { get; set; }

        public Veiculo()
        {
            this.criadoEm = DateTime.Now;
            this.locado = false;
            this.reservado = "0";
        }
    }
}
