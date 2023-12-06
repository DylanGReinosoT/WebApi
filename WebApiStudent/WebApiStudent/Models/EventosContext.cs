using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibrary.Models;

public partial class EventosContext : DbContext
{
    public EventosContext()
    {

    }

    public EventosContext(DbContextOptions<EventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comic> Comics { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comics__3214EC07D827C131");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libro__3214EC076FA4D815");

            entity.ToTable("Libro");

            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PK__Usuarios__EAEBAC8F1143FC2F");

            entity.Property(e => e.Clave)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
