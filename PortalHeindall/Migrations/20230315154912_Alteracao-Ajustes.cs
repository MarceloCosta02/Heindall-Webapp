using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHeindall.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Meta",
                table: "Meta");

            migrationBuilder.RenameTable(
                name: "Meta",
                newName: "Metas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metas",
                table: "Metas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Metas",
                table: "Metas");

            migrationBuilder.RenameTable(
                name: "Metas",
                newName: "Meta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meta",
                table: "Meta",
                column: "Id");
        }
    }
}
