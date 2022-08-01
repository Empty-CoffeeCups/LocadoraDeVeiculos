using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTabelaDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DevolucaoId",
                table: "TBTaxas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBDevolucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KmVeiculo = table.Column<int>(type: "int", nullable: false),
                    NivelDoTanque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDeDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDevolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBDevolucao_TBLocacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxas_DevolucaoId",
                table: "TBTaxas",
                column: "DevolucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDevolucao_LocacaoId",
                table: "TBDevolucao",
                column: "LocacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxas_TBDevolucao_DevolucaoId",
                table: "TBTaxas",
                column: "DevolucaoId",
                principalTable: "TBDevolucao",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxas_TBDevolucao_DevolucaoId",
                table: "TBTaxas");

            migrationBuilder.DropTable(
                name: "TBDevolucao");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxas_DevolucaoId",
                table: "TBTaxas");

            migrationBuilder.DropColumn(
                name: "DevolucaoId",
                table: "TBTaxas");
        }
    }
}
