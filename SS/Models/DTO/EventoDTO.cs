namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventoDTO
    {
        public EventoDTO(int id, string nombre, double? costo, string lugar, DateTime fecha_Hora_Salida, DateTime fecha_Hora_Regreso)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Costo = costo;
            this.Lugar = lugar;
            this.Fecha_Hora_Salida = fecha_Hora_Salida;
            this.Fecha_Hora_Regreso = fecha_Hora_Regreso;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public double? Costo { get; set; }

        public string Lugar { get; set; }

        public DateTime Fecha_Hora_Salida { get; set; }

        public DateTime Fecha_Hora_Regreso { get; set; }
    }
}
