using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class tMunicipio
    {
        [Key]
        public int MunicipioID { get; set; }

        [Display(Name = "Municipio Descripcion")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string MunicipioDesc { get; set; }

        [Display(Name = "Municipio Status")]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public enumMunicipioStatus MunicipioStatus { get; set; }

    }
}