namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EstadoDTO
    {

        public EstadoDTO(int id, string tipo)
        {
            this.Id = id;
            this.Tipo = tipo;
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
