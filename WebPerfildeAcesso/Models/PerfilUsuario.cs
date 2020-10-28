using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPerfildeAcesso.Models
{
    public class PerfilUsuario
    {
        [Display(Name = "Código")]

        [Column("Id")]
        public int Id { get; set; }


        [Display(Name = "TipoUsuario")]
        [ForeignKey("TipoUsuario")]
        [Column(Order = 1)]
        public int IdTipoUsuario { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("IdentityUser")]
        [Column(Order = 1)]
        public string IdentityUser { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}