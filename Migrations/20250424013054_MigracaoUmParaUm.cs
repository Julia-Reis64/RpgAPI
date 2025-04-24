using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 39, 145, 201, 175, 241, 236, 221, 2, 98, 27, 197, 180, 221, 65, 180, 240, 97, 81, 164, 52, 207, 169, 210, 124, 39, 156, 161, 45, 232, 206, 148, 9, 79, 14, 75, 255, 241, 210, 124, 97, 15, 141, 36, 53, 252, 162, 203, 17, 253, 153, 54, 67, 248, 129, 124, 191, 208, 103, 143, 93, 110, 13, 229, 212 }, new byte[] { 106, 156, 24, 18, 228, 26, 64, 64, 222, 221, 68, 113, 66, 222, 174, 212, 105, 204, 163, 153, 61, 163, 213, 238, 132, 83, 248, 179, 183, 187, 32, 13, 22, 112, 54, 89, 86, 22, 25, 83, 193, 78, 18, 108, 215, 121, 219, 189, 106, 134, 14, 103, 198, 146, 251, 124, 60, 248, 163, 226, 236, 238, 52, 235, 154, 107, 119, 172, 1, 149, 193, 235, 17, 148, 76, 28, 198, 52, 57, 214, 222, 26, 164, 188, 181, 29, 209, 14, 249, 123, 198, 172, 36, 223, 225, 143, 75, 67, 148, 149, 179, 90, 84, 177, 26, 140, 45, 74, 49, 1, 56, 16, 102, 5, 8, 149, 41, 129, 78, 152, 250, 220, 228, 90, 245, 44, 8, 146 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 77, 246, 40, 162, 17, 78, 61, 253, 213, 109, 191, 127, 221, 124, 80, 208, 166, 189, 68, 111, 207, 232, 16, 231, 172, 52, 17, 200, 115, 29, 21, 249, 71, 102, 21, 212, 29, 84, 91, 253, 27, 128, 82, 114, 48, 28, 0, 233, 208, 225, 12, 63, 196, 196, 19, 20, 175, 180, 178, 101, 130, 183, 149, 134 }, new byte[] { 199, 98, 133, 247, 110, 71, 172, 122, 170, 186, 93, 240, 143, 235, 196, 184, 91, 210, 141, 12, 177, 254, 253, 77, 38, 238, 102, 203, 208, 189, 156, 143, 149, 183, 161, 176, 76, 148, 254, 213, 223, 249, 11, 47, 15, 53, 180, 27, 40, 96, 218, 133, 123, 67, 62, 95, 86, 123, 202, 11, 195, 20, 75, 158, 37, 73, 34, 105, 29, 78, 104, 102, 89, 23, 188, 177, 183, 127, 242, 100, 94, 46, 119, 184, 3, 44, 25, 172, 178, 241, 228, 62, 159, 83, 145, 11, 160, 28, 19, 224, 150, 50, 240, 140, 215, 225, 247, 230, 117, 19, 115, 62, 105, 10, 218, 93, 206, 167, 210, 65, 21, 192, 205, 155, 92, 29, 133, 87 } });
        }
    }
}
