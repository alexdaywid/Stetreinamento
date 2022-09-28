using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stefanini.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Id_Cidade = table.Column<int>(type: "int", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pessoa_cidade_Id_Cidade",
                        column: x => x.Id_Cidade,
                        principalTable: "cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cidade",
                columns: new[] { "Id", "Nome", "UF" },
                values: new object[] { 1, "João Pessoa", "PB" });

            migrationBuilder.InsertData(
                table: "cidade",
                columns: new[] { "Id", "Nome", "UF" },
                values: new object[] { 2, "Cabedelo", "PB" });

            migrationBuilder.InsertData(
                table: "pessoa",
                columns: new[] { "Id", "CPF", "Id_Cidade", "Idade", "Nome" },
                values: new object[] { 1, "02021232445", 1, 38, "Alex Daywid" });

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_Id_Cidade",
                table: "pessoa",
                column: "Id_Cidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "cidade");
        }
    }
}
