using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171123233914_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Dificuldade", b =>
                {
                    b.Property<int>("DificuldadeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .HasMaxLength(60);

                    b.Property<string>("Observacao")
                        .HasMaxLength(60);

                    b.Property<int>("Valor");

                    b.HasKey("DificuldadeId");

                    b.ToTable("Dificuldades");
                });

            modelBuilder.Entity("Trails4Health.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .HasMaxLength(1000);

                    b.Property<string>("Nome")
                        .HasMaxLength(60);

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Trails4Health.Models.EstadoTrilho", b =>
                {
                    b.Property<int>("TrihoId");

                    b.Property<int>("EstadoId");

                    b.Property<string>("Causa")
                        .HasMaxLength(60);

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.HasKey("TrihoId", "EstadoId");

                    b.HasIndex("EstadoId");

                    b.ToTable("EstadosTrilhos");
                });

            modelBuilder.Entity("Trails4Health.Models.Etapa", b =>
                {
                    b.Property<int>("EtapaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AltitudeMax");

                    b.Property<int>("AltitudeMin");

                    b.Property<int>("DificuldadeId");

                    b.Property<string>("Fim")
                        .HasMaxLength(60);

                    b.Property<string>("Inicio")
                        .HasMaxLength(60);

                    b.Property<string>("Nome")
                        .HasMaxLength(60);

                    b.HasKey("EtapaId");

                    b.HasIndex("DificuldadeId");

                    b.ToTable("Etapas");
                });

            modelBuilder.Entity("Trails4Health.Models.EtapasTrilho", b =>
                {
                    b.Property<int>("EtapaId");

                    b.Property<int>("TrilhoId");

                    b.Property<int>("EtapasTrilhoId");

                    b.HasKey("EtapaId", "TrilhoId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("EtapasTrilhos");
                });

            modelBuilder.Entity("Trails4Health.Models.Foto", b =>
                {
                    b.Property<int>("FotoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("EstacaoAno")
                        .HasMaxLength(60);

                    b.Property<int>("LocalizacaoId");

                    b.Property<int>("Tipo");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("FotoId");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("Trails4Health.Models.FotosTrilho", b =>
                {
                    b.Property<int>("FotoId");

                    b.Property<int>("TrilhoId");

                    b.Property<string>("AnoMes");

                    b.Property<int>("FotosTrilhoId");

                    b.HasKey("FotoId", "TrilhoId");

                    b.HasIndex("TrilhoId");

                    b.ToTable("FotosTrilhos");
                });

            modelBuilder.Entity("Trails4Health.Models.Localizacao", b =>
                {
                    b.Property<int>("LocalizacaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EtapaId");

                    b.Property<string>("Nome")
                        .HasMaxLength(60);

                    b.HasKey("LocalizacaoId");

                    b.HasIndex("EtapaId");

                    b.ToTable("Localizacoes");
                });

            modelBuilder.Entity("Trails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrihoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AltitudeMax");

                    b.Property<int>("AltitudeMin");

                    b.Property<int>("BelezaPai");

                    b.Property<string>("Descricao")
                        .HasMaxLength(1000);

                    b.Property<string>("Fim")
                        .HasMaxLength(60);

                    b.Property<string>("Inicio")
                        .HasMaxLength(60);

                    b.Property<int>("InteresseHistorico");

                    b.Property<string>("Nome")
                        .HasMaxLength(60);

                    b.Property<bool>("Visivel");

                    b.HasKey("TrihoId");

                    b.ToTable("Trilhos");
                });

            modelBuilder.Entity("Trails4Health.Models.EstadoTrilho", b =>
                {
                    b.HasOne("Trails4Health.Models.Estado", "Estado")
                        .WithMany("EstadosTrilhos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trilho", "Trilho")
                        .WithMany("EstadosTrilhos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Etapa", b =>
                {
                    b.HasOne("Trails4Health.Models.Dificuldade", "Dificuldade")
                        .WithMany("Etapas")
                        .HasForeignKey("DificuldadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.EtapasTrilho", b =>
                {
                    b.HasOne("Trails4Health.Models.Etapa", "Etapa")
                        .WithMany("EtapasTrilhos")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trilho", "Trilho")
                        .WithMany("EtapasTrilhos")
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Foto", b =>
                {
                    b.HasOne("Trails4Health.Models.Localizacao", "Localizacao")
                        .WithMany("Fotos")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.FotosTrilho", b =>
                {
                    b.HasOne("Trails4Health.Models.Foto", "Foto")
                        .WithMany("FotosTrilhos")
                        .HasForeignKey("FotoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trilho", "Trilho")
                        .WithMany("FotosTrilhos")
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Localizacao", b =>
                {
                    b.HasOne("Trails4Health.Models.Etapa", "Etapa")
                        .WithMany("Localizacoes")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
