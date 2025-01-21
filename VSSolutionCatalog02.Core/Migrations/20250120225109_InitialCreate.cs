using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VSSolutionCatalog02.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "solutions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    path = table.Column<string>(type: "text", nullable: true),
                    size = table.Column<int>(type: "integer", nullable: true),
                    slncreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    slnmodified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    language = table.Column<string>(type: "text", nullable: true),
                    runtime = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<int>(type: "integer", nullable: true),
                    relocateto = table.Column<string>(type: "text", nullable: true),
                    disposition = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_solutions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "solutions");
        }
    }
}
