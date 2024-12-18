using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORMULARIOCENSI.Models
{
    [Table("t_estados")]
    public class Estados
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        public int Numero { get; set; }

        public string? Nombre { get; set; }

        [ForeignKey("Prueba")]
        public int FormularioId { get; set; }

        public Formulario? Formulario { get; set; }
    }
}