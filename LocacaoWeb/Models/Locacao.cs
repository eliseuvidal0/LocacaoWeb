using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoWeb.Models
{
    [Table("Locacoes")]
    public class Locacao
    {
        [Key]
        public virtual int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual Cliente cliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual Veiculo veiculo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual Funcionario funcionario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string formaPagamento { get; set; }
        public virtual double totalLocacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual DateTime previsaoEntrega { get; set; }
        public virtual DateTime criadoEm { get; set; }
        public virtual DateTime dataEntrega { get; set; }
        // valor a ser cobrado a mais caso exceda o período inicial
        public virtual double custoVariavel { get; set; }
        public virtual bool devolvido { get; set; }

        public Locacao()
        {
            this.funcionario = new Funcionario();
            this.cliente = new Cliente();
            this.veiculo = new Veiculo();
            this.criadoEm = DateTime.Now;
            this.devolvido = false;
            this.custoVariavel = 0;
        }
    }
}
