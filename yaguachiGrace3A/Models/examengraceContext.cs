using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace yaguachiGrace3A.Models
{
    public partial class examengraceContext : DbContext
    {
        public examengraceContext()
        {
        }

        public examengraceContext(DbContextOptions<examengraceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Detalleventum> Detalleventa { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //              optionsBuilder.UseSqlServer("Server=DESKTOP-LI62I77\\SQLEXPRESS01; DataBase=examengrace;Integrated Security=true; encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalleventum>(entity =>
            {
                entity.HasKey(e => e.CodigoDetalle)
                    .HasName("PK__detallev__EA0BDD19E3DE2977");

                entity.ToTable("detalleventa");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.CodigoProducto)
                    .HasConstraintName("FK__detalleve__Codig__403A8C7D");

                entity.HasOne(d => d.CodigoVentaNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.CodigoVenta)
                    .HasConstraintName("FK__detalleve__Codig__3F466844");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__producto__785B009E87FD30EA");

                entity.ToTable("producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioProducto).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.CodigoVenta)
                    .HasName("PK__venta__F2421464C85B22CC");

                entity.ToTable("venta");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
