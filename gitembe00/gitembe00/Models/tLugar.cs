using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class tLugar
    {
        [Key]
        public int LugarID { get; set; }

        [Display(Name = "Lugar")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string LugarDesc { get; set; }

        [Display(Name = "Lugar Status")]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public enumLugarStatus LugarStatus { get; set; }

    }
}