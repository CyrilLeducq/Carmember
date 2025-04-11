using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMember_server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiculeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    category = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    number_of_seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_salt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    profile_picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    vehicule_model_id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_VehiculeModels_vehicule_model_id",
                        column: x => x.vehicule_model_id,
                        principalTable: "VehiculeModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    reviewed_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    author_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_author_user_id",
                        column: x => x.author_user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_reviewed_user_id",
                        column: x => x.reviewed_user_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    departure_location_city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    departure_location_adress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    arrival_location_city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    arrival_location_adress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    cost_height = table.Column<int>(type: "int", nullable: false),
                    cost_cheese_type = table.Column<int>(type: "int", nullable: false),
                    musical_preference = table.Column<int>(type: "int", nullable: false),
                    animal_preference = table.Column<int>(type: "int", nullable: false),
                    smoking_preference = table.Column<int>(type: "int", nullable: false),
                    talking_preference = table.Column<int>(type: "int", nullable: false),
                    driver_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rides_Users_driver_user_id",
                        column: x => x.driver_user_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RideUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ride_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RideUsers_Rides_ride_id",
                        column: x => x.ride_id,
                        principalTable: "Rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RideUsers_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "creation_date", "email", "firstname", "gender", "lastname", "password", "password_salt", "phone_number", "profile_picture", "role", "vehicule_model_id" },
                values: new object[] { new Guid("315dd23f-0155-4196-90eb-f00e2db27014"), new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "edmond.dor@mail.com", "Edmond", "H", "d'Or", "TODO", "TODO", "+336888815", null, "user", null });

            migrationBuilder.InsertData(
                table: "VehiculeModels",
                columns: new[] { "Id", "category", "name", "number_of_seats" },
                values: new object[,]
                {
                    { new Guid("2eefbb1b-b7b0-4d0d-834a-90ca46f636c2"), 10, "Chèvre-O-lait", 5 },
                    { new Guid("66a15c74-4ee7-477d-85b2-a3f084c58142"), 2, "Munster-Truck", 4 }
                });

            migrationBuilder.InsertData(
                table: "Rides",
                columns: new[] { "Id", "animal_preference", "arrival_location_adress", "arrival_location_city", "cost_cheese_type", "cost_height", "departure_date", "departure_location_adress", "departure_location_city", "driver_user_id", "duration", "musical_preference", "smoking_preference", "talking_preference" },
                values: new object[] { new Guid("4253b6c2-a9ae-4ea9-97b4-2e88d5348a56"), 0, "4 parvis Victor Hugo, Dunkerque", "Dunkerque", 2, 600, new DateTime(2025, 4, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), "3 rue Faidherbe, 59000 Lille", "Lille", new Guid("315dd23f-0155-4196-90eb-f00e2db27014"), 60, 2, 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "creation_date", "email", "firstname", "gender", "lastname", "password", "password_salt", "phone_number", "profile_picture", "role", "vehicule_model_id" },
                values: new object[,]
                {
                    { new Guid("49f88bba-7235-44b3-9b03-2396a5d086a8"), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mozart.ella@mail.com", "Mozart", "F", "Ella", "TODO", "TODO", "+3368856115", null, "admin", new Guid("2eefbb1b-b7b0-4d0d-834a-90ca46f636c2") },
                    { new Guid("6d4b945a-8e33-4008-af4c-37fc28b893a4"), new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "igor.gonzolla@mail.com", "Igor", "H", "Gonzola", "TODO", "TODO", "+3361142415", null, "user", new Guid("66a15c74-4ee7-477d-85b2-a3f084c58142") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "author_user_id", "comment", "reviewed_user_id", "score" },
                values: new object[,]
                {
                    { new Guid("858eb3be-9850-49a7-9925-02c2c8f5229a"), new Guid("315dd23f-0155-4196-90eb-f00e2db27014"), "Super trajet avec Igor, peu bavard mais très accueuillant ! Edmond.", new Guid("6d4b945a-8e33-4008-af4c-37fc28b893a4"), 5 },
                    { new Guid("ff666e12-1475-41a8-ac4f-188eaf83cb6c"), new Guid("6d4b945a-8e33-4008-af4c-37fc28b893a4"), "Pas sympathique et trop bavard, Mozart est trop vieux jeu ! Igor", new Guid("49f88bba-7235-44b3-9b03-2396a5d086a8"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Rides",
                columns: new[] { "Id", "animal_preference", "arrival_location_adress", "arrival_location_city", "cost_cheese_type", "cost_height", "departure_date", "departure_location_adress", "departure_location_city", "driver_user_id", "duration", "musical_preference", "smoking_preference", "talking_preference" },
                values: new object[] { new Guid("95df620f-ae38-4e5a-8894-41332c14c4c5"), 1, "6 Avenue des Champs Elysées", "Paris", 6, 1000, new DateTime(2025, 4, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), "3 rue Faidherbe", "Lille", new Guid("6d4b945a-8e33-4008-af4c-37fc28b893a4"), 180, 3, 1, 3 });

            migrationBuilder.InsertData(
                table: "RideUsers",
                columns: new[] { "Id", "ride_id", "user_id" },
                values: new object[] { new Guid("729ec28d-8649-4ff4-a3da-74f776e05128"), new Guid("95df620f-ae38-4e5a-8894-41332c14c4c5"), new Guid("315dd23f-0155-4196-90eb-f00e2db27014") });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_author_user_id",
                table: "Reviews",
                column: "author_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_reviewed_user_id",
                table: "Reviews",
                column: "reviewed_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_driver_user_id",
                table: "Rides",
                column: "driver_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_RideUsers_ride_id",
                table: "RideUsers",
                column: "ride_id");

            migrationBuilder.CreateIndex(
                name: "IX_RideUsers_user_id",
                table: "RideUsers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_vehicule_model_id",
                table: "Users",
                column: "vehicule_model_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RideUsers");

            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehiculeModels");
        }
    }
}
