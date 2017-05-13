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
        private CategoriaDTO categoriaDTO;
        private CarreraDTO carreraDTO;
        private EventoDTO eventoDTO;
        private RecursoDTO recursoDTO;
        private ActividadDTO actividadDTO;
        private ValidacionDTO validacionDTO;
        private EstadoDTO estadoDTO;

        public SolicitudDTO(int id, string folio, string nombre_Solicitante, int numero_Empleado, 
            CategoriaDTO categoria, CarreraDTO carrera, EventoDTO evento, RecursoDTO recurso_Solicitado,
            ActividadDTO actividad, ValidacionDTO validacion, EstadoDTO estado, DateTime fecha_Creacion, 
            DateTime fecha_Modificacion, string correo_Solicitante, string comentario_Rechazado, 
            bool leido)
        {
            Id = id;
            Folio = folio;
            Nombre_Solicitante = nombre_Solicitante;
            Numero_Empleado = numero_Empleado;
            Categoria = categoria;
            Carrera = carrera;
            Evento = evento;
            Recurso_Solicitado = recurso_Solicitado;
            Actividad = actividad;
            Validacion = validacion;
            Estado = estado;
            Fecha_Creacion = fecha_Creacion;
            Fecha_Modificacion = fecha_Modificacion;
            Correo_Solicitante = correo_Solicitante;
            Comentario_Rechazado = comentario_Rechazado;
            Leido = leido;
        }

        public SolicitudDTO(int id, string folio, string nombre_Solicitante, int numero_Empleado, CategoriaDTO categoriaDTO, CarreraDTO carreraDTO, EventoDTO eventoDTO, RecursoDTO recursoDTO, ActividadDTO actividadDTO, ValidacionDTO validacionDTO, EstadoDTO estadoDTO, DateTime fecha_Creacion, DateTime fecha_Modificacion)
        {
            Id = id;
            Folio = folio;
            Nombre_Solicitante = nombre_Solicitante;
            Numero_Empleado = numero_Empleado;
            this.categoriaDTO = categoriaDTO;
            this.carreraDTO = carreraDTO;
            this.eventoDTO = eventoDTO;
            this.recursoDTO = recursoDTO;
            this.actividadDTO = actividadDTO;
            this.validacionDTO = validacionDTO;
            this.estadoDTO = estadoDTO;
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
