namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ValidacionDTO
    {
        public ValidacionDTO()
        {
        }

        public ValidacionDTO(int id, bool coordinador, bool subdirector, bool administrador, bool director, bool posgrado)
        {
            this.Id = id;
            this.Coordinador = coordinador;
            this.Subdirector = subdirector;
            this.Administrador = administrador;
            this.Director = director;
            this.Posgrado = posgrado;
        }

        public int Id { get; set; }

        public bool Coordinador { get; set; }

        public bool Subdirector { get; set; }

        public bool Administrador { get; set; }

        public bool Director { get; set; }

        public bool Posgrado { get; set; }
       

    }
}
