using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HifiBlog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BlogImg = table.Column<string>(type: "TEXT", nullable: true),
                    BlogName = table.Column<string>(type: "TEXT", nullable: true),
                    BlogText = table.Column<string>(type: "TEXT", nullable: true),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TypeOfUse = table.Column<string>(type: "TEXT", nullable: true),
                    ConnectionType = table.Column<string>(type: "TEXT", nullable: true),
                    JakType = table.Column<string>(type: "TEXT", nullable: true),
                    FrequencyRange = table.Column<string>(type: "TEXT", nullable: true),
                    SoundLoudity = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<string>(type: "TEXT", nullable: true),
                    DriveType = table.Column<string>(type: "TEXT", nullable: true),
                    ActiveNoiseCanceling = table.Column<string>(type: "TEXT", nullable: true),
                    Impedance = table.Column<string>(type: "TEXT", nullable: true),
                    BlogTag = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "preliminaryInormations",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PITitle = table.Column<string>(type: "TEXT", nullable: false),
                    PIText = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preliminaryInormations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SliderName = table.Column<string>(type: "TEXT", nullable: false),
                    SliderImg = table.Column<string>(type: "TEXT", nullable: false),
                    SliderText = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "preliminaryInormations");

            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
