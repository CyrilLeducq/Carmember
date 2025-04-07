using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMember_server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    cost_cheese_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    musical_preference = table.Column<int>(name: "musical_preference ", type: "int", nullable: false),
                    animal_preference = table.Column<int>(name: "animal_preference ", type: "int", nullable: false),
                    smoking_preference = table.Column<int>(name: "smoking_preference  ", type: "int", nullable: false),
                    talking_preference = table.Column<int>(name: "talking_preference  ", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                });

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
                    lasttname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_salt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    profile_picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_vehicule_model = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_VehiculeModels_id_vehicule_model",
                        column: x => x.id_vehicule_model,
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
                    id_reviewed_user = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    id_author_user = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_id_author_user",
                        column: x => x.id_author_user,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_id_reviewed_user",
                        column: x => x.id_reviewed_user,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RideUser",
                columns: table => new
                {
                    RidesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideUser", x => new { x.RidesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RideUser_Rides_RidesId",
                        column: x => x.RidesId,
                        principalTable: "Rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_id_author_user",
                table: "Reviews",
                column: "id_author_user");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_id_reviewed_user",
                table: "Reviews",
                column: "id_reviewed_user");

            migrationBuilder.CreateIndex(
                name: "IX_RideUser_UsersId",
                table: "RideUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_vehicule_model",
                table: "Users",
                column: "id_vehicule_model");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RideUser");

            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehiculeModels");
        }
    }
}
