using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTabelaLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBTaxas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanoDeCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotalPrevisto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBPlanoDeCobranca_PlanoDeCobrancaId",
                        column: x => x.PlanoDeCobrancaId,
                        principalTable: "TBPlanoDeCobranca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxas_LocacaoId",
                table: "TBTaxas",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CondutorId",
                table: "TBLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_FuncionarioId",
                table: "TBLocacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_PlanoDeCobrancaId",
                table: "TBLocacao",
                column: "PlanoDeCobrancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxas_TBLocacao_LocacaoId",
                table: "TBTaxas",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxas_TBLocacao_LocacaoId",
                table: "TBTaxas");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxas_LocacaoId",
                table: "TBTaxas");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBTaxas");
        }
    }
}
