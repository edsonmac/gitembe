using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class tCargo
    {
        [Key]
        public int CargoID { get; set; }

        [Display(Name = "Cargo Sigla")]
        [StringLength(200, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string CargoSigla { get; set; }

        [Display(Name = "Cargo Descripcion")]
        [StringLength(200, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string CargoDesc { get; set; }

        [Display(Name = "Cargo Status")]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public enumCargoStatus CargoStatus { get; set; }

    }
}