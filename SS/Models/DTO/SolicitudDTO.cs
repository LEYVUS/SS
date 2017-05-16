namespace SS.Models.DTO
{
    using SS.Models.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SolicitudDTO
    {

        public SolicitudDTO()
        {

        }

        public SolicitudDTO(string correo_Solicitante, int id, string folio, string nombre_Solicitante, int numero_Empleado, CategoriaDTO categoriaDTO, CarreraDTO carreraDTO, EventoDTO eventoDTO, RecursoDTO recursoDTO, ActividadDTO actividadDTO, ValidacionDTO validacionDTO, EstadoDTO estado, DateTime fecha_Creacion, DateTime fecha_Modificacion)
        {
            Correo_Solicitante = correo_Solicitante;
            Id = id;
            Folio = folio;
            Nombre_Solicitante = nombre_Solicitante;
            Numero_Empleado = numero_Empleado;
            this.Categoria = categoriaDTO;
            this.Carrera = carreraDTO;
            this.Evento = eventoDTO;
            this.Recurso_Solicitado = recursoDTO;
            this.Actividad = actividadDTO;
            this.Validacion = validacionDTO;
            this.Estado = estado;
            Fecha_Creacion = fecha_Creacion;
            Fecha_Modificacion = fecha_Modificacion;
        }

        public int Id { get; set; }

        public string Folio { get; set; }

        public string Nombre_Solicitante { get; set; }

        public int Numero_Empleado { get; set; }

        public CategoriaDTO Categoria { get; set; }

        public CarreraDTO Carrera { get; set; }

        public EventoDTO Evento { get; set; }

        public RecursoDTO Recurso_Solicitado { get; set; }

        public ActividadDTO Actividad { get; set; }

        public ValidacionDTO Validacion { get; set; }

        public EstadoDTO Estado { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }

        public String Correo_Solicitante { get; set; }

        public String Comentario_Rechazado { get; set; }

        public bool Leido { get; set; }


    }
}
