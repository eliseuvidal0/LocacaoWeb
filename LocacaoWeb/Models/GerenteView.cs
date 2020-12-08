using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.Models
{
    [Table("Gerentes")]
    public class GerenteView
    {
        [Key]
        public virtual int id { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [NotMapped]
        [Compare("senha", ErrorMessage = "Campos não coincidem!")]
        public string confirmarSenha { get; set; }
    }
}
