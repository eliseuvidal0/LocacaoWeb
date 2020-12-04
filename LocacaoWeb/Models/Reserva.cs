using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.Models
{
    [Table("Reservas")]
    public class Reserva
    {
        [Key]
        public virtual int id { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Veiculo veiculo { get; set; }
        public virtual string formaPagamento { get; set; }
        public virtual bool ativo { get; set; }
        public virtual DateTime criadoEm { get; set; }
        public virtual int cliID { get; set; }
        public virtual int vecID { get; set; }

        public Reserva()
        {
            this.cliente = new Cliente();
            this.veiculo = new Veiculo();
            this.criadoEm = DateTime.Now;
        }
    }
}
