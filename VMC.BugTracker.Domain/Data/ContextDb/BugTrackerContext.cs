using Microsoft.EntityFrameworkCore;
using System;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> contextOptions) : base(contextOptions) { }

        public DbSet<TipoGenerico> TipoGenerico { get; set; }
        public DbSet<EstadoGenerico> EstadoGenerico { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Incidencia> Incidencia { get; set; }
        public DbSet<IncidenciaAdjunto> IncidenciaAdjunto { get; set; }
        public DbSet<IncidenciaCambio> IncidenciaCambio { get; set; }
        public DbSet<IncidenciaComentario> IncidenciaComentario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Proyecto>();

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(p => p.ProyectoId);
                entity.Property(p => p.Nombre).IsRequired();
                entity.Property(p => p.EstadoId).IsRequired();
                entity.Property(p => p.TipoProyectoId).IsRequired();
                entity.Property(p => p.UsuarioResponsableId).IsRequired();
                entity.Property(p => p.UsuarioRegistroId).IsRequired();
                entity.Property(p => p.FechaRegistro).IsRequired();
                entity.HasOne(p => p.Estado);
                entity.HasOne(p => p.UsuarioRegistro);
                entity.HasOne(p => p.UsuarioResponsable);
                entity.HasOne(p => p.TipoProyecto);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(p => p.RolId);
                entity.HasOne(p => p.Proyecto);
                entity.HasMany(p => p.Usuarios);
                entity.Property(p => p.Nombre).IsRequired();
                entity.Property(p => p.EsAdministrador).IsRequired();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(p => p.UsuarioId);
                entity.Property(p => p.EstadoId).IsRequired();
                entity.Property(p => p.RolId).IsRequired();
                entity.Property(p => p.Correo).IsRequired();
                entity.Property(p => p.NombreCompleto).IsRequired();
                entity.Property(p => p.FechaRegistro).IsRequired();

                entity.HasOne(p => p.Estado);
                entity.HasOne(p => p.Rol).WithMany(p => p.Usuarios).HasForeignKey(p => p.RolId).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(p => p.IncidenciasAsignadas);
                entity.HasMany(p => p.IncidenciasRegistradas);
            });

            modelBuilder.Entity<EstadoGenerico>(entity =>
            {
                entity.HasKey(p => p.EstadoId);
                entity.Property(p => p.Nombre).IsRequired();
                entity.Property(p => p.EsActivo).IsRequired();
            });

            modelBuilder.Entity<TipoGenerico>(entity =>
            {
                entity.HasKey(p => p.TipoGenericoId);
                entity.Property(p => p.Nombre).IsRequired();
                entity.Property(p => p.EsActivo).IsRequired();
            });

            modelBuilder.HasSequence<int>("NumeroIncidencia")
                        .StartsAt(1)
                        .IncrementsBy(1);

            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.HasKey(p => p.IncidenciaId);
                entity.Property(p => p.NumeroIncidencia).HasDefaultValueSql("NEXT VALUE FOR dbo.NumeroIncidencia");
                entity.Property(p => p.Nombre).IsRequired();
                entity.Property(p => p.FechaRegistro).IsRequired();
                entity.Property(p => p.UsuarioRegistroId).IsRequired();
                entity.Property(p => p.ProyectoId).IsRequired();
                entity.Property(p => p.EstadoId).IsRequired();

                entity.HasOne(p => p.UsuarioRegistro).WithMany(p => p.IncidenciasRegistradas).HasForeignKey(p => p.UsuarioRegistroId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.UsuarioAsignado).WithMany(p => p.IncidenciasAsignadas).HasForeignKey(p => p.UsuarioAsignadoId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Proyecto).WithMany(p => p.Incidencias).HasForeignKey(p => p.ProyectoId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Estado);

                entity.HasMany(p => p.IncidenciaAdjuntos);
                entity.HasMany(p => p.IncidenciaCambios);
                entity.HasMany(p => p.IncidenciaComentarios);
            });



            modelBuilder.Entity<IncidenciaAdjunto>(entity =>
            {
                entity.HasKey(p => p.IncidenciaAdjuntoId);

                entity.Property(p => p.RutaVirtual).IsRequired();
                entity.Property(p => p.ExtensionArchivo).IsRequired();
                entity.Property(p => p.UsuarioId).IsRequired();
                entity.Property(p => p.FechaRegistro).IsRequired();
                entity.HasOne(p => p.Usuario);
                entity.HasOne(p => p.Incidencia).WithMany(p => p.IncidenciaAdjuntos).HasForeignKey(p => p.IncidenciaId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<IncidenciaCambio>(entity =>
            {
                entity.HasKey(p => p.IncidenciaCambioId);

                entity.Property(p => p.IncidenciaId).IsRequired();
                entity.Property(p => p.EstadoId).IsRequired();
                entity.Property(p => p.UsuarioId).IsRequired();
                entity.Property(p => p.FechaRegistro).IsRequired();

                entity.HasOne(p => p.Usuario);
                entity.HasOne(p => p.Incidencia).WithMany(p => p.IncidenciaCambios).HasForeignKey(p => p.IncidenciaId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Estado);
            });

            modelBuilder.Entity<IncidenciaComentario>(entity =>
            {
                entity.HasKey(p => p.IncidenciaComentarioId);
                entity.Property(p => p.Comentario).IsRequired();
                entity.Property(p => p.EstadoId).IsRequired();
                entity.Property(p => p.UsuarioId).IsRequired();
                entity.Property(p => p.FechaRegistro).IsRequired();

                entity.HasOne(p => p.Usuario);
                entity.HasOne(p => p.Incidencia).WithMany(p => p.IncidenciaComentarios).HasForeignKey(p => p.IncidenciaId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Estado);
            });
        }
    }
}
