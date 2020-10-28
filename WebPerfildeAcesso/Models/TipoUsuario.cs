using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPerfildeAcesso.Models
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Display(Name = "Código")]

        [Column("Id")]
        public int Id { get; set; }


        [Display(Name = "Usuario")]
        [Column("TipoUsuario")]
        public string Tipousuario { get; set; }
    }

}