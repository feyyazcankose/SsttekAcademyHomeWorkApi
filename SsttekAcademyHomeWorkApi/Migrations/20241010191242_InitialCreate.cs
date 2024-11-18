using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SsttekAcademyHomeWorkApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Author = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false),
                    ISBN = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Genre = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Publisher = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PageCount = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    AvailableCopies = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
