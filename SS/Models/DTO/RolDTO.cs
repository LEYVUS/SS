namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RolDTO
    {
        public RolDTO()
        {

        }

        public RolDTO(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

    }
}
