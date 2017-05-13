namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActividadDTO
    {
        

        public ActividadDTO(int Id, bool? CACEI, bool? Licenciatura, bool? Personal, bool? ISO, bool? Posgrado, string Otro)
        {
            this.Id = Id;
            this.CACEI = CACEI;
            this.Licenciatura = Licenciatura;
            this.Personal = Personal;
            this.ISO = ISO;
            this.Posgrado = Posgrado;
            this.Otro = Otro;
        }


        public int Id { get; set; }

        public bool? CACEI { get; set; }

        public bool? Licenciatura { get; set; }

        public bool? Personal { get; set; }

        public bool? ISO { get; set; }

        public bool? Posgrado { get; set; }

        public String Otro { get; set; }

    }
}
