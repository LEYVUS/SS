namespace SS.Models.Entidades.SS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evento")]
    public partial class Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evento()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        public double? Costo { get; set; }

        [Required]
        [StringLength(150)]
        public string Lugar { get; set; }

        public DateTime Fecha_Hora_Salida { get; set; }

        public DateTime Fecha_Hora_Regreso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
