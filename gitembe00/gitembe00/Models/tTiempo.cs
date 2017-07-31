using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class tTiempo
    {
        [Key]
        public int TiempoID { get; set; }

        [Display(Name = "Tiempo")]
        [StringLength(30, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string TiempoDesc { get; set; }
    }
}