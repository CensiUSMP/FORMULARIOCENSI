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

        [Column("DatosPaciente")]
        public string DatosPaciente { get; set;}

        [Column("sinopsis")]
        public string Sinopsis { get; set;}

        [Column("base")]
        public string Base { get; set;}

        [Column("estado1")]
        public string Estado1 { get; set;}

        [Column("estado2")]
        public string Estado2 { get; set;}

        [Column("estado3")]
        public string Estado3 { get; set;}

        [Column("estado4")]
        public string Estado4 { get; set;}

        [Column("estado5")]
        public string Estado5 { get; set;}

        [Column("estado6")]
        public string Estado6 { get; set;}

        [Column("estado7")]
        public string Estado7 { get; set;}

        [Column("autores")]
        public string Autores { get; set;}

        [Column("historia_clinica")]
        public string HistoriaClinica { get; set;}

        [Column("situacion_triaje")]
        public string SituaciónTriaje { get; set;}

        [Column("nota_hospitalizacion")]
        public string NotaHospitalizacion { get; set;}

        [Column("signos_vitales")]
        public string SignosVitales { get; set;}

        [Column("estado_general")]
        public string EstadoGeneral { get; set;}

        [Column("cardiovascular")]
        public string Cardiovascular { get; set;}

        [Column("cuello")]
        public string Cuello { get; set;}

        [Column("respiratorio")]
        public string Respiratorio { get; set;}

        [Column("abdomen")]
        public string Abdomen { get; set;}

        [Column("genito_urinario")]
        public string GenitoUrinario { get; set;}

        [Column("aparato_locomotor")]
        public string AparatoLocomotor { get; set;}

        [Column("piel")]
        public string Piel { get; set;}

        [Column("neurologico")]
        public string Neurologico { get; set;}

        [Column("endovenoso")]
        public string Endovenoso { get; set;}

        [Column("laboratorios")]
        public string Laboratorios { get; set;}

        [Column("recomendaciones")]
        public string Recomendaciones { get; set;}

        [Column("ordenes")]
        public string Ordenes { get; set;}

        [Column("competencia_general")]
        public string CompetenciaGeneral { get; set;}

        [Column("objetivos")]
        public string Objetivos { get; set;}

        [Column("identificar")]
        public string Identificar { get; set;}

        [Column("distinguir")]
        public string Distinguir { get; set;}

        [Column("discriminar")]
        public string Discriminar { get; set;}

        [Column("actuar")]
        public string Actuar { get; set;}

        [Column("usar")]
        public string Usar { get; set;}

        [Column("aplicar")]
        public string Aplicar { get; set;}

        [Column("Medidas_esenciales")]
        public string MedidasEsenciales { get; set;}

        [Column("baseline")]
        public string Baseline { get; set;}

        [Column("estado1_desem")]
        public string Estado1Desem { get; set;}

        [Column("estado2_desem")]
        public string Estado2Desem { get; set;}

        [Column("estado3_desem")]
        public string Estado3Desem { get; set;}

        [Column("estado4_desem")]
        public string Estado4Desem { get; set;}

        [Column("estado5_desem")]
        public string Estado5Desem { get; set;}

        [Column("estado6_desem")]
        public string Estado6Desem { get; set;}

        [Column("estado7_desem")]
        public string Estado7Desem { get; set;}

        [Column("estado8_desem")]
        public string Estado8Desem { get; set;}

        [Column("preguntas")]
        public string Preguntas { get; set;}

        [Column("equipos")]
        public string Equipos { get; set;}
        
        [Column("confederado")]
        public string Confederado { get; set;}

        [Column("definiciones")]
        public string Definiciones { get; set;}

        [Column("herramientas")]
        public string Herramientas { get; set;}

        [Column("monitor_desfibrilador")]
        public string MonitorDesfibrilador { get; set;}

        [Column("enfoque")]
        public string Enfoque { get; set;}

        [Column("control")]
        public string Control { get; set;}

        [Column("bibliografía")]
        public string Bibliografía { get; set;}

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
