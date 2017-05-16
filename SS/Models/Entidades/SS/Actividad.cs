namespace SS.Models.Entidades.SS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Actividad")]
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int Id { get; set; }

        public bool? CACEI { get; set; }

        public bool? Licenciatura { get; set; }

        public bool? Personal { get; set; }

        public bool? ISO { get; set; }

        public bool? Posgrado { get; set; }

        [StringLength(100)]
        public string Otro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
