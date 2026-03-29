using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppRentAcar.Migrations
{
    /// <inheritdoc />
    public partial class CreateSeedDataForCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Description", "Model", "Passengers", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "BMW", "Diesel, automatic, navigation", "320d", 5, 120m, 2018 },
                    { 2, "Audi", "Petrol, automatic, leather seats", "A4", 5, 130m, 2019 },
                    { 3, "Mercedes", "Diesel, automatic, premium interior", "C220", 5, 150m, 2020 },
                    { 4, "VW", "Petrol, manual, economical", "Golf 7", 5, 80m, 2017 },
                    { 5, "Toyota", "Hybrid, automatic, low consumption", "Corolla", 5, 110m, 2021 },
                    { 6, "Ford", "Diesel, manual, comfortable", "Focus", 5, 90m, 2018 },
                    { 7, "Honda", "Petrol, automatic, sporty", "Civic", 5, 115m, 2019 },
                    { 8, "Hyundai", "Petrol, manual, reliable", "i30", 5, 85m, 2020 },
                    { 9, "Kia", "Petrol, automatic, modern", "Ceed", 5, 95m, 2021 },
                    { 10, "Skoda", "Diesel, automatic, spacious", "Octavia", 5, 105m, 2019 },
                    { 11, "Nissan", "SUV, petrol, automatic", "Qashqai", 5, 140m, 2020 },
                    { 12, "Mazda", "SUV, petrol, premium feel", "CX-5", 5, 145m, 2021 },
                    { 13, "Peugeot", "SUV, diesel, stylish", "3008", 5, 135m, 2018 },
                    { 14, "Renault", "Diesel, manual, budget", "Megane", 5, 75m, 2017 },
                    { 15, "Opel", "Petrol, manual, practical", "Astra", 5, 80m, 2018 },
                    { 16, "Tesla", "Electric, autopilot, premium", "Model 3", 5, 200m, 2022 },
                    { 17, "Volvo", "SUV, hybrid, safety features", "XC60", 5, 180m, 2021 },
                    { 18, "Jeep", "SUV, 4x4, off-road capable", "Compass", 5, 150m, 2020 },
                    { 19, "Dacia", "SUV, budget, reliable", "Duster", 5, 70m, 2019 },
                    { 20, "Seat", "Petrol, sporty, modern", "Leon", 5, 100m, 2021 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
