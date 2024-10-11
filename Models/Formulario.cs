using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORMULARIOCENSI.Models
{
    [Table("t_formulario")]
    public class Formulario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set;}

        [Column("titulo")]
        public string Titulo { get; set;}

        [Column("sinopsis")]
        public string Sinopsis { get; set;}

        [Column("autores")]
        public string Autores { get; set;}

        [Column("historia_clinica")]
        public string HistoriaClinica { get; set;}

        [Column("nota_ingreso")]
        public string NotaIngreso { get; set;}

        [Column("ordenes")]
        public string Ordenes { get; set;}

        [Column("objetivos")]
        public string Objetivos { get; set;}

        [Column("desempeno")]
        public string Desempeño { get; set;}

        [Column("preguntas")]
        public string Preguntas { get; set;}

        [Column("equipos")]
        public string Equipos { get; set;}

        [Column("guion")]
        public string Guión { get; set;}

        [Column("confederado")]
        public string Confederado { get; set;}

        [Column("notas_facilitador")]
        public string NotasFacilitador { get; set;}

        [Column("puntos_debriefing")]
        public string PuntosDebriefing { get; set;}

        [Column("aprendizaje")]
        public string Aprendizaje { get; set;}

        [Column("referencias")]
        public string Referencias { get; set;}

        [Column("escenarios")]
        public string Escenarios { get; set;}
    }
}
