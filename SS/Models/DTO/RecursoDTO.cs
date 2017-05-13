namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RecursoDTO
    {

        public RecursoDTO(int id, bool? hospedaje, int? transporte, bool? combustible, bool? viatico, bool? oficio_Comision, String otro)
        {
            this.Id = id;
            this.Hospedaje = hospedaje;
            this.Transporte = transporte;
            this.Combustible = combustible;
            this.Viatico = viatico;
            this.Oficio_Comision = oficio_Comision;
            this.Otro = otro;
        }

        public int Id { get; set; }

        public bool? Hospedaje { get; set; }

        public int? Transporte { get; set; }

        public bool? Combustible { get; set; }

        public bool? Viatico { get; set; }

        public bool? Oficio_Comision { get; set; }

        [StringLength(250)]
        public string Otro { get; set; }
    }
}
