using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HifiBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIText",
                table: "preliminaryInormations");

            migrationBuilder.AlterColumn<string>(
                name: "PITitle",
                table: "preliminaryInormations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "preliminaryInormations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PITitle",
                table: "preliminaryInormations",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "preliminaryInormations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PIText",
                table: "preliminaryInormations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
