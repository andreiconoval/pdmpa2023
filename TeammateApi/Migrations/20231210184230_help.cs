using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeammateApi.Migrations
{
    /// <inheritdoc />
    public partial class help : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_adresses",
                columns: table => new
                {
                    user_uid = table.Column<string>(type: "TEXT", nullable: true),
                    map_latitude = table.Column<string>(type: "TEXT", nullable: true),
                    map_longitude = table.Column<string>(type: "TEXT", nullable: true),
                    label = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "user_profile",
                columns: table => new
                {
                    user_uid = table.Column<string>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: true),
                    last_name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_profile", x => x.user_uid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_adresses");

            migrationBuilder.DropTable(
                name: "user_profile");
        }
    }
}
