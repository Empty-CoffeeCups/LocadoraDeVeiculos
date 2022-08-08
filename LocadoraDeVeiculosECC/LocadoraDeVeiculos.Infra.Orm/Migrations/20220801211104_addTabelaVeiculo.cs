using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class addTabelaVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GruposDeVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoDeCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeDoTanque = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KmPercorrido = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoDeVeiculos_GruposDeVeiculosId",
                        column: x => x.GruposDeVeiculosId,
                        principalTable: "TBGrupoDeVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GruposDeVeiculosId",
                table: "TBVeiculo",
                column: "GruposDeVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBVeiculo");
        }
    }
}
