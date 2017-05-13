using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SS.Models.DTO
{


    public partial class CategoriaDTO
    {

        public CategoriaDTO(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
