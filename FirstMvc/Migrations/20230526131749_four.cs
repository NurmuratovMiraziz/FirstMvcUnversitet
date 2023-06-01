using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMvc.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talabas_Unversitetlar_UnversitetId",
                table: "Talabas");

            migrationBuilder.RenameColumn(
                name: "UnversitetId",
                table: "Talabas",
                newName: "UnversitetsId");

            migrationBuilder.RenameIndex(
                name: "IX_Talabas_UnversitetId",
                table: "Talabas",
                newName: "IX_Talabas_UnversitetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talabas_Unversitetlar_UnversitetsId",
                table: "Talabas",
                column: "UnversitetsId",
                principalTable: "Unversitetlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talabas_Unversitetlar_UnversitetsId",
                table: "Talabas");

            migrationBuilder.RenameColumn(
                name: "UnversitetsId",
                table: "Talabas",
                newName: "UnversitetId");

            migrationBuilder.RenameIndex(
                name: "IX_Talabas_UnversitetsId",
                table: "Talabas",
                newName: "IX_Talabas_UnversitetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Talabas_Unversitetlar_UnversitetId",
                table: "Talabas",
                column: "UnversitetId",
                principalTable: "Unversitetlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
