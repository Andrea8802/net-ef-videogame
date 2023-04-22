using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_SoftwareHouse_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "videogame",
                newName: "software_house_id");

            migrationBuilder.RenameIndex(
                name: "IX_videogame_SoftwareHouseId",
                table: "videogame",
                newName: "IX_videogame_software_house_id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_SoftwareHouse_software_house_id",
                table: "videogame",
                column: "software_house_id",
                principalTable: "SoftwareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_SoftwareHouse_software_house_id",
                table: "videogame");

            migrationBuilder.RenameColumn(
                name: "software_house_id",
                table: "videogame",
                newName: "SoftwareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_videogame_software_house_id",
                table: "videogame",
                newName: "IX_videogame_SoftwareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_SoftwareHouse_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId",
                principalTable: "SoftwareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
