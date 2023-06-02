using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpraApi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Staff",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Staff",
                columns: new[] { "Id", "AddressLine", "City", "Country", "CreatedAt", "CreatedBy", "DateOfBirth", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Phone", "Province", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Suite 958", "Eltonburgh", "Tokelau", new DateTime(2023, 5, 11, 18, 59, 53, 513, DateTimeKind.Utc).AddTicks(5361), "admin", new DateTime(1961, 1, 31, 18, 38, 40, 803, DateTimeKind.Local).AddTicks(8710), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "golda.medhurst65@yahoo.com", "Lila", "Jerde", "02593920767", "Arizona", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Suite 382", "Rennerhaven", "Svalbard & Jan Mayen", new DateTime(2023, 5, 11, 18, 59, 53, 513, DateTimeKind.Utc).AddTicks(7812), "admin", new DateTime(1983, 11, 28, 3, 15, 42, 759, DateTimeKind.Local).AddTicks(9295), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jasper.orn@yahoo.com", "Simon", "Hessel", "56777845347", "Utah", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "Apt. 705", "Christianhaven", "Spain", new DateTime(2023, 5, 11, 18, 59, 53, 513, DateTimeKind.Utc).AddTicks(8980), "admin", new DateTime(1953, 7, 7, 10, 29, 41, 681, DateTimeKind.Local).AddTicks(4144), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "octavia62@yahoo.com", "Irma", "Rippin", "07583051385", "Wisconsin", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "Apt. 149", "Santosport", "Guyana", new DateTime(2023, 5, 11, 18, 59, 53, 513, DateTimeKind.Utc).AddTicks(9981), "admin", new DateTime(1988, 4, 24, 17, 33, 20, 316, DateTimeKind.Local).AddTicks(5453), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "kevin.ebert@hotmail.com", "Emanuel", "Goodwin", "49592807627", "New York", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "Apt. 953", "Rosemaryside", "Ecuador", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(981), "admin", new DateTime(1974, 5, 17, 21, 43, 42, 882, DateTimeKind.Local).AddTicks(6651), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "keyon28@yahoo.com", "Mindy", "Weimann", "36159936155", "New Hampshire", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "Suite 551", "Wittingview", "Vietnam", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(1960), "admin", new DateTime(1995, 2, 28, 23, 33, 12, 940, DateTimeKind.Local).AddTicks(9797), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "talon.okon80@gmail.com", "Rosalie", "Sauer", "28993956525", "Vermont", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "Apt. 734", "Brodystad", "Israel", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(3044), "admin", new DateTime(1979, 6, 21, 20, 43, 42, 78, DateTimeKind.Local).AddTicks(6131), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jensen_fritsch48@hotmail.com", "Norman", "Ferry", "61253474805", "Montana", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "Suite 341", "South Janickville", "Belgium", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(4127), "admin", new DateTime(2001, 7, 26, 11, 44, 3, 110, DateTimeKind.Local).AddTicks(216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "drew.veum7@yahoo.com", "Ismael", "Franecki", "35376781283", "Maryland", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "Apt. 495", "Barrowstown", "Uzbekistan", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(5143), "admin", new DateTime(1993, 5, 17, 8, 33, 3, 570, DateTimeKind.Local).AddTicks(444), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "elnora_kuhn23@yahoo.com", "Maggie", "Kutch", "11541860751", "Missouri", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "Apt. 980", "West Darrellfort", "Turkey", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(6111), "admin", new DateTime(1972, 6, 2, 2, 37, 59, 75, DateTimeKind.Local).AddTicks(1394), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "antwon_olson@gmail.com", "Keith", "Hermiston", "67768189642", "North Carolina", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "Apt. 192", "Bartonfurt", "Singapore", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(7136), "admin", new DateTime(1983, 11, 22, 2, 12, 5, 918, DateTimeKind.Local).AddTicks(7684), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pamela9@gmail.com", "Salvatore", "Cruickshank", "75159480493", "Virginia", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "Suite 035", "Meganeton", "Austria", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(8116), "admin", new DateTime(1979, 9, 23, 17, 44, 5, 479, DateTimeKind.Local).AddTicks(972), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jorge4@hotmail.com", "Ada", "Gorczany", "61895856222", "Missouri", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "Suite 852", "Hilpertfurt", "Brazil", new DateTime(2023, 5, 11, 18, 59, 53, 514, DateTimeKind.Utc).AddTicks(9065), "admin", new DateTime(1972, 7, 14, 14, 5, 11, 624, DateTimeKind.Local).AddTicks(8830), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "keshawn.cronin64@yahoo.com", "Kevin", "Hartmann", "76300989874", "New Hampshire", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "Apt. 179", "Lake Hudsonland", "Syrian Arab Republic", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(31), "admin", new DateTime(1964, 3, 5, 22, 54, 41, 523, DateTimeKind.Local).AddTicks(4937), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "eli_greenfelder29@hotmail.com", "Harold", "Johnson", "17747050378", "Delaware", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "Suite 575", "Klingview", "American Samoa", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(1050), "admin", new DateTime(1964, 7, 2, 3, 39, 8, 616, DateTimeKind.Local).AddTicks(3594), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "jamey.moen55@hotmail.com", "Guillermo", "Toy", "26193445153", "Massachusetts", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, "Apt. 004", "Port Wilhelmine", "Norway", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(1989), "admin", new DateTime(1988, 8, 28, 0, 16, 5, 783, DateTimeKind.Local).AddTicks(4311), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "joey_wolff17@hotmail.com", "Patrick", "Schimmel", "94990264983", "Utah", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, "Suite 859", "Lake Jaquelinport", "Latvia", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(3021), "admin", new DateTime(1963, 8, 21, 7, 33, 41, 668, DateTimeKind.Local).AddTicks(873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahsaan51@hotmail.com", "Anne", "Jacobson", "65569297143", "Vermont", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, "Suite 564", "Buckridgemouth", "Saint Kitts and Nevi", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(4025), "admin", new DateTime(1990, 1, 7, 16, 18, 35, 559, DateTimeKind.Local).AddTicks(1742), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "devante_maggio@gmail.com", "Kristen", "Marvin", "94806122011", "Georgia", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, "Apt. 513", "North Carlottamouth", "Luxembourg", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(4990), "admin", new DateTime(1953, 7, 21, 9, 31, 40, 297, DateTimeKind.Local).AddTicks(6443), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dariana30@hotmail.com", "Luis", "Boehm", "53089341363", "Idaho", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, "Suite 572", "Peytonfurt", "Albania", new DateTime(2023, 5, 11, 18, 59, 53, 515, DateTimeKind.Utc).AddTicks(5936), "admin", new DateTime(1968, 2, 22, 0, 56, 47, 493, DateTimeKind.Local).AddTicks(2305), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anabel23@hotmail.com", "Matt", "Greenfelder", "34575265074", "Virginia", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Email",
                schema: "dbo",
                table: "Staff",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Id",
                schema: "dbo",
                table: "Staff",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_LastName_Country",
                schema: "dbo",
                table: "Staff",
                columns: new[] { "LastName", "Country" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff",
                schema: "dbo");
        }
    }
}
