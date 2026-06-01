using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.ProductService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Intelligent Concrete Bacon", 329.17m, 53 },
                    { 2, "Fantastic Rubber Chips", 377.24m, 134 },
                    { 3, "Sleek Cotton Towels", 467.79m, 140 },
                    { 4, "Unbranded Concrete Sausages", 238.14m, 22 },
                    { 5, "Gorgeous Rubber Table", 314.31m, 118 },
                    { 6, "Handmade Steel Shoes", 109.04m, 117 },
                    { 7, "Awesome Rubber Bike", 320.22m, 113 },
                    { 8, "Unbranded Rubber Chair", 38.82m, 76 },
                    { 9, "Gorgeous Concrete Keyboard", 51.63m, 101 },
                    { 10, "Refined Plastic Cheese", 197.41m, 48 },
                    { 11, "Handmade Granite Chicken", 215.68m, 55 },
                    { 12, "Sleek Rubber Tuna", 281.26m, 80 },
                    { 13, "Handcrafted Granite Mouse", 289.10m, 141 },
                    { 14, "Refined Frozen Gloves", 306.47m, 85 },
                    { 15, "Refined Concrete Pants", 104.49m, 47 },
                    { 16, "Handmade Wooden Gloves", 162.89m, 141 },
                    { 17, "Practical Steel Bike", 218.32m, 142 },
                    { 18, "Intelligent Steel Sausages", 462.73m, 93 },
                    { 19, "Handcrafted Rubber Car", 22.96m, 47 },
                    { 20, "Licensed Granite Shirt", 146.48m, 94 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
