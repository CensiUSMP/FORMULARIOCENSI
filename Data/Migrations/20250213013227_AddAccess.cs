using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FORMULARIOCENSI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "t_formulario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userid",
                table: "t_formulario");
        }
    }
}
