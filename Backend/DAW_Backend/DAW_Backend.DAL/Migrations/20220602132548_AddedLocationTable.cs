using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Backend.DAL.Migrations
{
    public partial class AddedLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "streetNumber",
                table: "Addresses",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Addresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Addresses",
                newName: "City");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpVotes = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Addresses",
                newName: "streetNumber");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Addresses",
                newName: "city");
        }
    }
}
