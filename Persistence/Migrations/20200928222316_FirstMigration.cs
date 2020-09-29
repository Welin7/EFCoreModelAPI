using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreModelAPI.Persistence.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoStore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVideoStore = table.Column<string>(maxLength: 256, nullable: true, defaultValue: "Video Store Standard"),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDirector = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    MovieStoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directors_VideoStore_MovieStoreId",
                        column: x => x.MovieStoreId,
                        principalTable: "VideoStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMovie = table.Column<string>(nullable: true),
                    VideoStoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_VideoStore_VideoStoreId",
                        column: x => x.VideoStoreId,
                        principalTable: "VideoStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VideoStore",
                columns: new[] { "Id", "Active", "NameVideoStore" },
                values: new object[] { 1, false, "Steven Spielberg" });

            migrationBuilder.InsertData(
                table: "VideoStore",
                columns: new[] { "Id", "Active", "NameVideoStore" },
                values: new object[] { 2, false, "Stanley Kucrick" });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_MovieStoreId",
                table: "Directors",
                column: "MovieStoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_VideoStoreId",
                table: "Movies",
                column: "VideoStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "VideoStore");
        }
    }
}
