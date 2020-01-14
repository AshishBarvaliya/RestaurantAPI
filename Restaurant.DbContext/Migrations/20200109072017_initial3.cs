using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.DbContext.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "City", "Lat", "Lng", "Locality", "Name", "Postcode", "State", "Street" },
                values: new object[] { 4, "Surat", 23.102, 23.102, "Simada", "Red Chilli Hotel", "2323", "Gujarat", "Varachha" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Rating", "RestaurantId" },
                values: new object[] { 7, 5, 4 });

            migrationBuilder.UpdateData(
                table: "RestaurantCuisines",
                keyColumn: "Id",
                keyValue: 7,
                column: "RestaurantId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RestaurantCuisines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "RestaurantCuisines",
                columns: new[] { "Id", "CuisineTypeId", "RestaurantId" },
                values: new object[] { 7, 1, 3 });
        }
    }
}
