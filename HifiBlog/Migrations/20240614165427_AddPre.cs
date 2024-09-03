using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HifiBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddPre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "preliminaryInormations",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "preliminaryInormations");
        }
    }
}
