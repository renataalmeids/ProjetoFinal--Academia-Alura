using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPerfildeAcesso.Models
{
    public class AcessoUsuario
    {
        [Display(Name = "Credencial")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Cargo")]
        [Column("NomeOcupação")]
        public string NomeOcupação { get; set; }

        [Display(Name = "TipoUsuario")]
        [ForeignKey("TipoUsuario")]
        [Column(Order = 1)]
        public int IdTipoUsuario { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
    }

}