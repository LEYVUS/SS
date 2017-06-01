namespace SS.Models.Entidades.FIAD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntidadesFIAD : DbContext
    {
        public EntidadesFIAD()
            : base("name=EntidadesFIAD")
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
