using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMvc.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Manzili",
                table: "Talabas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ismi",
                table: "Talabas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UnversitetsId",
                table: "Talabas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Unversitetlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unversitetlar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talabas_UnversitetsId",
                table: "Talabas",
                column: "UnversitetsId");

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

            migrationBuilder.DropTable(
                name: "Unversitetlar");

            migrationBuilder.DropIndex(
                name: "IX_Talabas_UnversitetsId",
                table: "Talabas");

            migrationBuilder.DropColumn(
                name: "UnversitetsId",
                table: "Talabas");

            migrationBuilder.AlterColumn<string>(
                name: "Manzili",
                table: "Talabas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ismi",
                table: "Talabas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
