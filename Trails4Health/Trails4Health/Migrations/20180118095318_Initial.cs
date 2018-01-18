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
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldades", x => x.DificuldadeId);
                });

            migrationBuilder.CreateTable(
                name: "EstacoesAno",
                columns: table => new
                {
                    EstacaoAnoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstacoesAno", x => x.EstacaoAnoId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.LocalizacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposFotos",
                columns: table => new
                {
                    TipoFotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposFotos", x => x.TipoFotoId);
                });

            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AltitudeMax = table.Column<int>(nullable: false),
                    AltitudeMin = table.Column<int>(nullable: false),
                    BelezaPai = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    DuracaoMedia = table.Column<int>(nullable: false),
                    Fim = table.Column<string>(maxLength: 60, nullable: false),
                    GrauDificuldade = table.Column<int>(nullable: false),
                    Inicio = table.Column<string>(maxLength: 60, nullable: false),
                    InteresseHistorico = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Visivel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhoId);
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
                    Fim = table.Column<string>(maxLength: 100, nullable: false),
                    Inicio = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
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
                name: "Fotos",
                columns: table => new
                {
                    FotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    EstacaoAnoId = table.Column<int>(nullable: false),
                    ImageMimeType = table.Column<string>(nullable: true),
                    Imagem = table.Column<byte[]>(nullable: true),
                    LocalizacaoId = table.Column<int>(nullable: false),
                    TipoFotoId = table.Column<int>(nullable: false),
                    Visivel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.FotoId);
                    table.ForeignKey(
                        name: "FK_Fotos_EstacoesAno_EstacaoAnoId",
                        column: x => x.EstacaoAnoId,
                        principalTable: "EstacoesAno",
                        principalColumn: "EstacaoAnoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fotos_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fotos_TiposFotos_TipoFotoId",
                        column: x => x.TipoFotoId,
                        principalTable: "TiposFotos",
                        principalColumn: "TipoFotoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadosTrilhos",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false),
                    TrihoId = table.Column<int>(nullable: false),
                    Causa = table.Column<string>(maxLength: 100, nullable: true),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    EstadoTrihoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTrilhos", x => new { x.EstadoId, x.TrihoId });
                    table.ForeignKey(
                        name: "FK_EstadosTrilhos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadosTrilhos_Trilhos_TrihoId",
                        column: x => x.TrihoId,
                        principalTable: "Trilhos",
                        principalColumn: "TrilhoId",
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
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotosTrilhos",
                columns: table => new
                {
                    FotoId = table.Column<int>(nullable: false),
                    TrilhoId = table.Column<int>(nullable: false),
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
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadosTrilhos_TrihoId",
                table: "EstadosTrilhos",
                column: "TrihoId");

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_DificuldadeId",
                table: "Etapas",
                column: "DificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapasTrilhos_TrilhoId",
                table: "EtapasTrilhos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_EstacaoAnoId",
                table: "Fotos",
                column: "EstacaoAnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_LocalizacaoId",
                table: "Fotos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_TipoFotoId",
                table: "Fotos",
                column: "TipoFotoId");

            migrationBuilder.CreateIndex(
                name: "IX_FotosTrilhos_TrilhoId",
                table: "FotosTrilhos",
                column: "TrilhoId");
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
                name: "Etapas");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Trilhos");

            migrationBuilder.DropTable(
                name: "Dificuldades");

            migrationBuilder.DropTable(
                name: "EstacoesAno");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "TiposFotos");
        }
    }
}
