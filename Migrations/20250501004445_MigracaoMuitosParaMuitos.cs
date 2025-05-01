using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Elemento",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HabilidadeId",
                table: "TB_ARMAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false),
                    Elemento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false),
                    Elemento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Elemento", "HabilidadeId" },
                values: new object[] { 0, null });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Elemento", "Nome" },
                values: new object[,]
                {
                    { 1, 39, 5, "Combustão" },
                    { 2, 41, 2, "Penumbra" },
                    { 3, 37, 3, "Dama de Cálcio" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 123, 38, 210, 32, 113, 143, 181, 151, 11, 8, 73, 230, 3, 129, 95, 171, 24, 232, 166, 46, 35, 98, 0, 32, 237, 95, 69, 237, 47, 51, 151, 175, 136, 96, 143, 116, 181, 51, 38, 188, 250, 104, 162, 8, 18, 87, 177, 177, 48, 226, 139, 239, 71, 156, 206, 134, 16, 179, 136, 53, 99, 160, 120, 199 }, new byte[] { 19, 200, 243, 44, 125, 60, 138, 139, 32, 169, 237, 68, 116, 25, 51, 169, 138, 53, 212, 180, 60, 170, 254, 155, 29, 61, 94, 208, 220, 95, 127, 23, 88, 57, 244, 32, 103, 3, 46, 2, 60, 142, 107, 222, 102, 221, 1, 26, 104, 133, 91, 118, 40, 52, 240, 196, 64, 193, 107, 92, 113, 57, 246, 200, 199, 176, 234, 110, 195, 137, 229, 237, 244, 237, 91, 238, 30, 173, 43, 137, 245, 194, 32, 20, 218, 27, 114, 101, 53, 194, 221, 51, 206, 83, 136, 246, 95, 31, 217, 167, 109, 40, 20, 236, 39, 110, 145, 161, 13, 129, 167, 104, 191, 138, 169, 100, 77, 14, 221, 67, 136, 168, 17, 232, 197, 190, 73, 13 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId", "Elemento" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 2, 2, 0 },
                    { 2, 3, 0 },
                    { 3, 3, 0 },
                    { 3, 4, 0 },
                    { 1, 5, 0 },
                    { 2, 6, 0 },
                    { 3, 7, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_HabilidadeId",
                table: "TB_ARMAS",
                column: "HabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_HABILIDADES_HabilidadeId",
                table: "TB_ARMAS",
                column: "HabilidadeId",
                principalTable: "TB_HABILIDADES",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_HABILIDADES_HabilidadeId",
                table: "TB_ARMAS");

            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_HabilidadeId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Elemento",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "HabilidadeId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 39, 145, 201, 175, 241, 236, 221, 2, 98, 27, 197, 180, 221, 65, 180, 240, 97, 81, 164, 52, 207, 169, 210, 124, 39, 156, 161, 45, 232, 206, 148, 9, 79, 14, 75, 255, 241, 210, 124, 97, 15, 141, 36, 53, 252, 162, 203, 17, 253, 153, 54, 67, 248, 129, 124, 191, 208, 103, 143, 93, 110, 13, 229, 212 }, new byte[] { 106, 156, 24, 18, 228, 26, 64, 64, 222, 221, 68, 113, 66, 222, 174, 212, 105, 204, 163, 153, 61, 163, 213, 238, 132, 83, 248, 179, 183, 187, 32, 13, 22, 112, 54, 89, 86, 22, 25, 83, 193, 78, 18, 108, 215, 121, 219, 189, 106, 134, 14, 103, 198, 146, 251, 124, 60, 248, 163, 226, 236, 238, 52, 235, 154, 107, 119, 172, 1, 149, 193, 235, 17, 148, 76, 28, 198, 52, 57, 214, 222, 26, 164, 188, 181, 29, 209, 14, 249, 123, 198, 172, 36, 223, 225, 143, 75, 67, 148, 149, 179, 90, 84, 177, 26, 140, 45, 74, 49, 1, 56, 16, 102, 5, 8, 149, 41, 129, 78, 152, 250, 220, 228, 90, 245, 44, 8, 146 } });
        }
    }
}
