using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectADO.Net1.Migrations
{
    /// <inheritdoc />
    public partial class TTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FatherName", "Name", "Popularity", "Surname" },
                values: new object[,]
                {
                    { 1, "Grigorievich", "Taras", 100, "Shevchenko" },
                    { 2, "Yosypovych", "Ivan", 95, "Franko" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "PopularityMonth", "PopularityWeek", "PopularityYear" },
                values: new object[,]
                {
                    { 1, "Fiction", 90, 80, 70 },
                    { 2, "Non-Fiction", 60, 70, 80 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Address 1", "Publishing House 1" },
                    { 2, "Address 2", "Publishing House 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "password1", "user1" },
                    { 2, "password2", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CostPrice", "GenreId", "IsContinuation", "IsOnPromotion", "IsSold", "PageCount", "Popularity", "PromotionEndDate", "PublicationYear", "PublisherId", "SalePrice", "SalesCount", "Title" },
                values: new object[,]
                {
                    { 1, 1, 10.00m, 1, false, false, false, 200, 50, null, 2020, 1, 15.00m, 0, "Book 1" },
                    { 2, 2, 20.00m, 2, false, true, false, 300, 60, new DateTime(2024, 10, 29, 18, 21, 21, 732, DateTimeKind.Local).AddTicks(3303), 2021, 2, 25.00m, 0, "Book 2" }
                });

            migrationBuilder.InsertData(
                table: "UserBooks",
                columns: new[] { "BookId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserBooks",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserBooks",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
