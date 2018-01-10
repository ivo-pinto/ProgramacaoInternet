﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Health.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Dificuldade> Dificuldades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstadoTrilho> EstadosTrilhos { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<EtapasTrilho> EtapasTrilhos { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<FotosTrilho> FotosTrilhos { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Trilho> Trilhos { get; set; }
        public DbSet<TipoFoto> TiposFotos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dificuldade>().HasKey(d => new { d.DificuldadeId});
            modelBuilder.Entity<Estado>().HasKey(e => new { e.EstadoId });
            modelBuilder.Entity<EstadoTrilho>().HasKey(et => new { et.TrihoId, et.EstadoId });
            modelBuilder.Entity<Etapa>().HasKey(e => new { e.EtapaId });
            modelBuilder.Entity<EtapasTrilho>().HasKey(et => new { et.EtapaId, et.TrilhoId });
            modelBuilder.Entity<Foto>().HasKey(f => new { f.FotoId });
            modelBuilder.Entity<FotosTrilho>().HasKey(ft => new { ft.FotoId, ft.TrilhoId });
            modelBuilder.Entity<Localizacao>().HasKey(l => new { l.LocalizacaoId });
            modelBuilder.Entity<Trilho>().HasKey(t => new { t.TrihoId });
           


            // Etapa Foreign Key
            modelBuilder.Entity<Etapa>()
                .HasOne<Dificuldade>(e => e.Dificuldade)
                .WithMany(d => d.Etapas)
                .HasForeignKey(e => e.DificuldadeId);


            // EtapasTrilho Foreign Key
            modelBuilder.Entity<EtapasTrilho>()
                .HasOne(et => et.Trilho)
                .WithMany(et => et.EtapasTrilhos)
                .HasForeignKey(et => et.TrilhoId);
            modelBuilder.Entity<EtapasTrilho>()
                 .HasOne(et => et.Etapa)
                 .WithMany(et => et.EtapasTrilhos)
                 .HasForeignKey(et => et.EtapaId);


            // Foto Foreign Key
            modelBuilder.Entity<Foto>()
                .HasOne<Localizacao>(l => l.Localizacao)
                .WithMany(l => l.Fotos)
                .HasForeignKey(f => f.LocalizacaoId);

            // TipoFoto Foreign Key
            modelBuilder.Entity<TipoFoto>()
                .HasOne<Foto>(l => l.Foto)
                .WithMany(l => l.TiposFotos)
                .HasForeignKey(f => f.FotoId);


            // EstadoTrilho Foreign Key
            modelBuilder.Entity<EstadoTrilho>()
                .HasOne(et => et.Trilho)
                .WithMany(t => t.EstadosTrilhos)
                .HasForeignKey(et => et.EstadoId);
            modelBuilder.Entity<EstadoTrilho>()
                 .HasOne(et => et.Estado)
                 .WithMany(e => e.EstadosTrilhos)
                 .HasForeignKey(et => et.EstadoId);


            // FotosTrilho Foreign Key
            modelBuilder.Entity<FotosTrilho>()
                .HasOne(ft => ft.Foto)
                .WithMany(f => f.FotosTrilhos)
                .HasForeignKey(ft => ft.FotoId);
            modelBuilder.Entity<FotosTrilho>()
                 .HasOne(ft => ft.Trilho)
                 .WithMany(t => t.FotosTrilhos)
                 .HasForeignKey(ft => ft.TrilhoId);


        }

    }
}
