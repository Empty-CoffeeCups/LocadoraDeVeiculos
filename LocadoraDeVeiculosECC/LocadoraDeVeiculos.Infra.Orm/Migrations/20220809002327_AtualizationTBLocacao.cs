using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizationTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VeiculoId",
                table: "TBLocacao",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId",
                principalTable: "TBVeiculo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                table: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "TBLocacao");
        }
    }
}
