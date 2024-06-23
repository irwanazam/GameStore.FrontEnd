using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.FrontEnd.Migrations
{
    /// <inheritdoc />
    public partial class Add_GenreName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreName",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreName",
                table: "Games");
        }
    }
}
