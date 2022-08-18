using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_ecfinal.Models
{
    public partial class BDEcfinalContext : DbContext
    {
        public BDEcfinalContext()
        {
        }

        public BDEcfinalContext(DbContextOptions<BDEcfinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BDEcfinal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });
        }
    }
}
