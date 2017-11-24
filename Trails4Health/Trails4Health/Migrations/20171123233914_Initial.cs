using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dificuldades",
                columns: table => new
                {
                    DificuldadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 60, nullable: true),
                    Observacao = table.Column<string>(maxLength: 60, nullable: true),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldades", x => x.DificuldadeId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrihoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AltitudeMax = table.Column<int>(nullable: false),
                    AltitudeMin = table.Column<int>(nullable: false),
                    BelezaPai = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Fim = table.Column<string>(maxLength: 60, nullable: true),
                    Inicio = table.Column<string>(maxLength: 60, nullable: true),
                    InteresseHistorico = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: true),
                    Visivel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrihoId);
                });

            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    EtapaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AltitudeMax = table.Column<int>(nullable: false),
                    AltitudeMin = table.Column<int>(nullable: false),
                    DificuldadeId = table.Column<int>(nullable: false),
                    Fim = table.Column<string>(maxLength: 60, nullable: true),
                    Inicio = table.Column<string>(maxLength: 60, nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.EtapaId);
                    table.ForeignKey(
                        name: "FK_Etapas_Dificuldades_DificuldadeId",
                        column: x => x.DificuldadeId,
                        principalTable: "Dificuldades",
                        principalColumn: "DificuldadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadosTrilhos",
                columns: table => new
                {
                    TrihoId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Causa = table.Column<string>(maxLength: 60, nullable: true),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTrilhos", x => new { x.TrihoId, x.EstadoId });
                    table.ForeignKey(
                        name: "FK_EstadosTrilhos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadosTrilhos_Trilhos_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrihoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtapasTrilhos",
                columns: table => new
                {
                    EtapaId = table.Column<int>(nullable: false),
                    TrilhoId = table.Column<int>(nullable: false),
                    EtapasTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapasTrilhos", x => new { x.EtapaId, x.TrilhoId });
                    table.ForeignKey(
                        name: "FK_EtapasTrilhos_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "EtapaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtapasTrilhos_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrihoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EtapaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.LocalizacaoId);
                    table.ForeignKey(
                        name: "FK_Localizacoes_Etapas_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapas",
                        principalColumn: "EtapaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    FotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(nullable: false),
                    EstacaoAno = table.Column<string>(maxLength: 60, nullable: true),
                    LocalizacaoId = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.FotoId);
                    table.ForeignKey(
                        name: "FK_Fotos_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotosTrilhos",
                columns: table => new
                {
                    FotoId = table.Column<int>(nullable: false),
                    TrilhoId = table.Column<int>(nullable: false),
                    AnoMes = table.Column<string>(nullable: true),
                    FotosTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosTrilhos", x => new { x.FotoId, x.TrilhoId });
                    table.ForeignKey(
                        name: "FK_FotosTrilhos_Fotos_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Fotos",
                        principalColumn: "FotoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotosTrilhos_Trilhos_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrihoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadosTrilhos_EstadoId",
                table: "EstadosTrilhos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_DificuldadeId",
                table: "Etapas",
                column: "DificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapasTrilhos_TrilhoId",
                table: "EtapasTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_LocalizacaoId",
                table: "Fotos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FotosTrilhos_TrilhoId",
                table: "FotosTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacoes_EtapaId",
                table: "Localizacoes",
                column: "EtapaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosTrilhos");

            migrationBuilder.DropTable(
                name: "EtapasTrilhos");

            migrationBuilder.DropTable(
                name: "FotosTrilhos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Etapas");

            migrationBuilder.DropTable(
                name: "Dificuldades");
        }
    }
}
