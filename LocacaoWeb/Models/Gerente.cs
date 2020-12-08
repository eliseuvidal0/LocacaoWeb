using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoWeb.Models
{
    public class Gerente : IdentityUser
    {
        public Gerente() => criadoEm = DateTime.Now;
        public DateTime criadoEm { get; set; }
    }
}
