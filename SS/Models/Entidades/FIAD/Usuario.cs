namespace SS.Models.Entidades.FIAD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Numero_Empleado { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
