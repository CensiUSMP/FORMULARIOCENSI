using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORMULARIOCENSI.Models
{
    [Table("t_respacademico")]
    public class RespAcademico
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id {get;set;}
        public string? NomAcad {get;set;}
    }
}