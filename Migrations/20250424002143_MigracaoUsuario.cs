using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_ARMAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false),
                    Raridade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ARMAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ARMAS",
                columns: new[] { "Id", "Dano", "Nome", "Raridade" },
                values: new object[,]
                {
                    { 1, 25, "Tíbia (sim o osso da perna)", 1 },
                    { 2, 40, "Machado de Execução", 2 },
                    { 3, 25, "Cajado Candelabro", 3 },
                    { 4, 30, "Pedaço de Pilar", 3 },
                    { 5, 30, "Pistoleta Trevosa", 1 },
                    { 6, 35, "Foice", 4 },
                    { 7, 45, "Crânio Mágico (sei lá)", 4 }
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FotoPersonagem", "UsuarioID" },
                values: new object[] { null, 1 });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 77, 246, 40, 162, 17, 78, 61, 253, 213, 109, 191, 127, 221, 124, 80, 208, 166, 189, 68, 111, 207, 232, 16, 231, 172, 52, 17, 200, 115, 29, 21, 249, 71, 102, 21, 212, 29, 84, 91, 253, 27, 128, 82, 114, 48, 28, 0, 233, 208, 225, 12, 63, 196, 196, 19, 20, 175, 180, 178, 101, 130, 183, 149, 134 }, new byte[] { 199, 98, 133, 247, 110, 71, 172, 122, 170, 186, 93, 240, 143, 235, 196, 184, 91, 210, 141, 12, 177, 254, 253, 77, 38, 238, 102, 203, 208, 189, 156, 143, 149, 183, 161, 176, 76, 148, 254, 213, 223, 249, 11, 47, 15, 53, 180, 27, 40, 96, 218, 133, 123, 67, 62, 95, 86, 123, 202, 11, 195, 20, 75, 158, 37, 73, 34, 105, 29, 78, 104, 102, 89, 23, 188, 177, 183, 127, 242, 100, 94, 46, 119, 184, 3, 44, 25, 172, 178, 241, 228, 62, 159, 83, 145, 11, 160, 28, 19, 224, 150, 50, 240, 140, 215, 225, 247, 230, 117, 19, 115, 62, 105, 10, 218, 93, 206, 167, 210, 65, 21, 192, 205, 155, 92, 29, 133, 87 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_UsuarioID",
                table: "TB_PERSONAGENS",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioID",
                table: "TB_PERSONAGENS",
                column: "UsuarioID",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioID",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropTable(
                name: "TB_ARMAS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PERSONAGENS_UsuarioID",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "TB_PERSONAGENS");
        }
    }
}
