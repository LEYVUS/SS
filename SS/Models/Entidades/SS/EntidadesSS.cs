namespace SS.Models.Entidades.SS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntidadesSS : DbContext
    {
        public EntidadesSS()
            : base("name=EntidadesSS")
        {
        }

        public virtual DbSet<Actividad> Actividads { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Evento> Eventoes { get; set; }
        public virtual DbSet<Recurso> Recursoes { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Solicitud> Solicituds { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Validacion> Validacions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Actividad)
                .HasForeignKey(e => e.Id_Actividad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Carrera>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Carrera)
                .HasForeignKey(e => e.Id_Carrera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.Id_Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.Id_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Evento)
                .HasForeignKey(e => e.Id_Evento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recurso>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Recurso)
                .HasForeignKey(e => e.Id_Recurso_Solicitado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.Id_Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.Correo_Solicitante)
                .IsFixedLength();

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Carreras)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Id_Usuario_Coordinador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Validacion>()
                .HasMany(e => e.Solicituds)
                .WithRequired(e => e.Validacion)
                .HasForeignKey(e => e.Id_Validacion)
                .WillCascadeOnDelete(false);
        }
    }
}
