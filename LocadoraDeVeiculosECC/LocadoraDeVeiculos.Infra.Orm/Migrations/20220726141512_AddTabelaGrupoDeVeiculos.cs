using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTabelaGrupoDeVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoDeVeiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoGrupo = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoDeVeiculos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGrupoDeVeiculos");
        }
    }
}
