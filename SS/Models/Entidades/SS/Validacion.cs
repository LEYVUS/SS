namespace SS.Models.Entidades.SS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Validacion")]
    public partial class Validacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Validacion()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int Id { get; set; }

        public bool Coordinador { get; set; }

        public bool Subdirector { get; set; }

        public bool Administrador { get; set; }

        public bool Director { get; set; }

        public bool Posgrado { get; set; }

        public bool Unica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
