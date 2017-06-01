namespace SS.Models.Entidades.UABC
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
        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Contraseña { get; set; }

        [Key]
        [Column(Order = 4)]
        public int Numero_Empleado { get; set; }
    }
}
