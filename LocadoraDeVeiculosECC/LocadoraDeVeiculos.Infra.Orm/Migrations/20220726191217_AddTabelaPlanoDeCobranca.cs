using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTabelaPlanoDeCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoDeCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDePlano = table.Column<string>(type: "varchar(50)", nullable: false),
                    ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorKmIncluso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoKmRodado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrupoDeVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoDeCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoDeCobranca_TBGrupoDeVeiculos_GrupoDeVeiculoId",
                        column: x => x.GrupoDeVeiculoId,
                        principalTable: "TBGrupoDeVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeVeiculoId",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");
        }
    }
}
