﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.API.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F4D0FA085");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro__3213E83F4EF90651");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro_Cl__3213E83FCBD81741");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LceEntregue).IsFixedLength();

            entity.HasOne(d => d.LceIdClienteNavigation)
                .WithMany(p => p.LivroClienteEmprestimos)
                .HasForeignKey(d => d.LceIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Livro_Cli__LceId__48CFD27E");

            entity.HasOne(d => d.LceIdLivroNavigation)
                .WithMany(p => p.LivroClienteEmprestimos)
                .HasForeignKey(d => d.LceIdLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Livro_Cli__LceId__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}