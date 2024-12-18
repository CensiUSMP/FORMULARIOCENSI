using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORMULARIOCENSI.Models
{
    [Table("t_dialogo")]
    public class Dialogo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Personaje { get; set; }

        public string? Guion { get; set; }

        [ForeignKey("Prueba")]
        public int FormularioId { get; set; }

        public Formulario? Formulario { get; set; }
    }
}