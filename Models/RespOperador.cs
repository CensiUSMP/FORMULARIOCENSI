using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORMULARIOCENSI.Models
{
    [Table("t_respoperador")]
    public class RespOperador
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id {get;set;}
        public string? NomOpe {get;set;}
    }
}