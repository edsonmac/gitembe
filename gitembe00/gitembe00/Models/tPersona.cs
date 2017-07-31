using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class tPersona
    {
        [Key]
        public int PersonaID { get; set; }

        [Display(Name = "Documento Identidad")]
        [StringLength(20, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string DocIdentidad { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Apellidos { get; set; }

        [Display(Name = "Persona Status")]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public enumPersonaStatus PersonaStatus { get; set; }
    }
}