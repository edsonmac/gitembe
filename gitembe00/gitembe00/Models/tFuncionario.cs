using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class tFuncionario
    {
        [Key]
        public int FuncionarioID { get; set; }

        [Display(Name = "Item")]
        [StringLength(10, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "Debe ingresar el campo {0}")]
        public string Item { get; set; }

        public double Basico { get; set; }

        public int CargoID { get; set; }

        public int PersonaID { get; set; }

        public int TiempoID { get; set; }

        public int EscalafonID { get; set; }

        public int LugarID { get; set; }

        public int MunicipioID { get; set; }



        public virtual tCargo tCargo { get; set; }
        public virtual tPersona tPersona { get; set; }
        public virtual tTiempo tTiempo { get; set; }
        public virtual tEscalafon tEscalafon { get; set; }
        public virtual tLugar tLugares { get; set; }
        public virtual tMunicipio tMunicipios { get; set; }
    }
}