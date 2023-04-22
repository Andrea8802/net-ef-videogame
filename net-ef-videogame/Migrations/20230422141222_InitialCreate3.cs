using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_SoftwareHouse_software_house_id",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareHouse",
                table: "SoftwareHouse");

            migrationBuilder.RenameTable(
                name: "SoftwareHouse",
                newName: "software_house");

            migrationBuilder.AddPrimaryKey(
                name: "PK_software_house",
                table: "software_house",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_software_house_software_house_id",
                table: "videogame",
                column: "software_house_id",
                principalTable: "software_house",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_software_house_software_house_id",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_software_house",
                table: "software_house");

            migrationBuilder.RenameTable(
                name: "software_house",
                newName: "SoftwareHouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareHouse",
                table: "SoftwareHouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_SoftwareHouse_software_house_id",
                table: "videogame",
                column: "software_house_id",
                principalTable: "SoftwareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
