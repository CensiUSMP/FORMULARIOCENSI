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
        public int Id { get; set; }

        [Column("userid")]
        public string UserId { get; set; }

        [Column("titulo")]
        public string? Titulo { get; set; }

        [Column("sinopsis")]
        public string? Sinopsis { get; set; }


        public List<Estados>? Estados { get; set; }

        public List<Estadosa>? Estadosa { get; set; }

        [Column("Imagen")]
        public Byte[]? Imagen { get; set; }
        [Column("imagename")]
        public String? ImagenName { get; set; }

        [Column("autores")]
        public string? Autores { get; set; }

        [Column("historial_medico")]
        [Display(Name = "Historial médico")]
        public string? Historial_medico { get; set; }

        [Column("alergias")]
        [Display(Name = "Alergias")]
        public string? Alergias { get; set; }

        [Column("medicamentos")]
        [Display(Name = "Medicamentos")]
        public string? Medicamentos { get; set; }

        [Column("historial_familiar")]
        [Display(Name = "Historia Familiar/Social")]
        public string? Historia_familiar { get; set; }

        [Column("situacion")]
        [Display(Name = "Situación")]
        public string? Situacion { get; set; }

        [Column("nota_de_hospitalizacion")]
        [Display(Name = "Nota de hospitalización")]
        public string? Nota_de_hospitalizacion { get; set; }

        [Column("signos_vitales")]
        [Display(Name = "Signos vitales")]
        public string? Signos_vitales { get; set; }

        [Column("estado_general")]
        [Display(Name = "Estado general")]
        public string? Estado_general { get; set; }

        [Column("piel")]
        [Display(Name = "Piel")]
        public string? Piel { get; set; }

        [Column("torax")]
        [Display(Name = "Tórax")]
        public string? Torax { get; set; }

        [Column("cv")]
        [Display(Name = "Cervical")]
        public string? CV { get; set; }

        [Column("abdomen")]
        [Display(Name = "Abdomen")]
        public string? Abdomen { get; set; }

        [Column("neurologico")]
        [Display(Name = "Neurológico")]
        public string? Neurologico { get; set; }

        [Column("laboratorio")]
        public string? Laboratorio { get; set; }

        [Column("Imagena")]
        public Byte[]? Imagena { get; set; }

        [Column("imagenamea")]
        public String? ImagenNamea { get; set; }

        [Column("orden_inicial")]
        [Display(Name = "Orden inicial")]
        public string? Orden_inicial { get; set; }

        [Column("distinguir")]
        public string? Distinguir { get; set; }

        [Column("indicar")]
        public string? Indicar { get; set; }

        [Column("analizar")]
        public string? Analizar { get; set; }

        [Column("evaluación")]
        public string? Evaluación { get; set; }

        [Column("aplicar")]
        public string? Aplicar { get; set; }

        [Column("medidas_esenciales")]
        [Display(Name = "Medidas esenciales de rendimiento del escenario")]
        public string? Medidas_esenciales { get; set; }

        [Column("baseline")]
        public string? Baseline { get; set; }

        [Column("preguntas_de_preparacion")]
        [Display(Name = "Preguntas de preparación")]
        public string? Preguntas_de_preparacion { get; set; }

        [Column("equipos_de_suministro")]
        [Display(Name = "Equipo de suministro")]
        public string? Equipos_de_suministro { get; set; }

        public List<Dialogo>? Dialogo { get; set; }

        [Column("confederado")]
        public string? Confederado { get; set; }

        [Column("archivo")]
        public Byte[]? Archivo { get; set; }

        [Column("archivo_name")]
        public String? ArchivoName { get; set; }

        [Display(Name = "Texto extraído")]
        public string? ArchivoTextoExtraido { get; set; }

        [Column("introduccion")]
        public string? Introduccion { get; set; }

        [Column("emociones")]
        public string? Emociones { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("analisis")]
        public string? Analisis { get; set; }

        [Column("sintesis")]
        public string? Sintesis { get; set; }

        [Column("preguntasdd")]
        [Display(Name = "Preguntas del debriefing")]
        public string? PreguntasDD { get; set; }

        [Column("baselineapren")]
        [Display(Name = "Baseline")]
        public string? BaselineApren { get; set; }

        [Column("referenciasb")]
        [Display(Name = "Referencias bibliográficas")]
        public string? ReferenciasB { get; set; }

        [Column("escenariosp")]
        [Display(Name = "Escenarios precargados")]
        public string? EscenariosP { get; set; }

        public List<Status>? Status { get; set; }

        [Column("Imagenc")]
        public Byte[]? Imagenc { get; set; }

        [Column("imagenamec")]
        public String? ImagenNamec { get; set; }
    }
}
