using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpraApi.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordRetryCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4810), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industrial", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4819), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sports", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("48537adc-4408-4c6f-af02-c48e4c1762e6"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4828), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Outdoors", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("645648a5-69ee-4494-bd3c-f7ff58e798ca"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4780), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Electronics", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("7145b74f-6789-48ea-9363-d01074fb65b5"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4800), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Health", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("7f8c207e-2e58-48ef-a109-8aced3a0384f"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4760), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kids", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("9a06c1dd-b246-4c95-a570-0edbd496a69a"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4345), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Games", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4858), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Home", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("e0672d1b-4077-482d-98b4-e95d4aaf3a81"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4791), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Movies", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("e6acfc95-4ed3-4ed8-bba5-3b8dbc1afe20"), new DateTime(2023, 6, 2, 16, 34, 20, 24, DateTimeKind.Utc).AddTicks(4848), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Garden", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastActivity", "LastName", "Password", "Role", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("f4df9be0-78af-4078-86b4-d1ba2919ee38"), new DateTime(2023, 6, 2, 16, 34, 20, 30, DateTimeKind.Utc).AddTicks(9549), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@simpra.com", "admin", new DateTime(2023, 6, 2, 16, 34, 20, 30, DateTimeKind.Utc).AddTicks(9551), "admin", new byte[] { 140, 105, 118, 229, 181, 65, 4, 21, 189, 233, 8, 189, 77, 238, 21, 223, 177, 103, 169, 200, 115, 252, 75, 184, 168, 31, 111, 42, 180, 72, 169, 24 }, "admin", "active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "Tag", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { new Guid("02dbaf08-2bb0-4068-b3ce-ae328be96f1a"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8164), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licensed Rubber Chair", "added", "2396343321642", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://andreanne.com" },
                    { new Guid("0cd74a8a-895f-4d9a-9c30-ff56ba053073"), new Guid("9a06c1dd-b246-4c95-a570-0edbd496a69a"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8565), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Concrete Towels", "added", "6880293335867", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://della.org" },
                    { new Guid("0e8361b2-da21-45fd-948a-1a5f718f65d5"), new Guid("7f8c207e-2e58-48ef-a109-8aced3a0384f"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7277), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Steel Bike", "added", "0354673901639", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://emelie.net" },
                    { new Guid("1dcd8991-5627-4a7e-a0d7-35a86c823453"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7056), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Granite Keyboard", "added", "9438709288176", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://krystina.com" },
                    { new Guid("23ddd884-895c-47ac-bd47-1c1e4c4e4442"), new Guid("9a06c1dd-b246-4c95-a570-0edbd496a69a"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8436), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Fresh Car", "added", "5606872516738", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://anita.com" },
                    { new Guid("24cb83ea-74f6-490e-85e6-9938541308a8"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7587), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Rubber Shirt", "added", "2951028120714", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://luciano.biz" },
                    { new Guid("27f8e31a-d15a-4fd8-a83c-38f89614812d"), new Guid("e6acfc95-4ed3-4ed8-bba5-3b8dbc1afe20"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8521), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Concrete Tuna", "added", "1455935950262", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://eliezer.biz" },
                    { new Guid("29c3da26-ab82-4e89-94a2-811883ac830b"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8613), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Rubber Chair", "added", "4283717858935", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://flavie.name" },
                    { new Guid("29e6057f-a9c3-4913-9729-73ce676a2616"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7183), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Concrete Sausages", "added", "7190227454472", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://ashly.com" },
                    { new Guid("2dac0c77-19cd-4862-a724-113f4564528d"), new Guid("9a06c1dd-b246-4c95-a570-0edbd496a69a"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7841), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Soft Computer", "added", "4378780307838", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://hal.name" },
                    { new Guid("321300f3-3cca-42dc-b707-54b1977bd852"), new Guid("e0672d1b-4077-482d-98b4-e95d4aaf3a81"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7889), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Frozen Pizza", "added", "7454939440261", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://hailee.info" },
                    { new Guid("32a0024a-0b4f-492e-934c-3f3a5f25a6d8"), new Guid("7f8c207e-2e58-48ef-a109-8aced3a0384f"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8066), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Metal Pants", "added", "2222723559827", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://samson.biz" },
                    { new Guid("3343a58f-e897-4c04-94c3-ab2119af8f99"), new Guid("7145b74f-6789-48ea-9363-d01074fb65b5"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6649), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Rubber Cheese", "added", "2492864289123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://carleton.org" },
                    { new Guid("36ab90bb-cad4-4e1f-8b5f-b035a6e2c501"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8394), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Granite Cheese", "added", "2233226529422", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://naomi.name" },
                    { new Guid("3a84dbaa-ad67-4931-92f3-1f98730bad60"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7978), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Wooden Tuna", "added", "9974371990301", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://monte.info" },
                    { new Guid("3ccdb491-e59c-4db6-bafb-73a1b78160eb"), new Guid("48537adc-4408-4c6f-af02-c48e4c1762e6"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7934), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Rubber Hat", "added", "2857183622721", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://katelynn.info" },
                    { new Guid("40dcd584-b404-46d2-a4ee-1151c3a22273"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8351), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Rubber Pants", "added", "2623108112628", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://lavern.org" },
                    { new Guid("42d7dbd4-0a92-47f4-aedf-639cf0c5e33b"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8741), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Wooden Shoes", "added", "4098625591894", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://jaclyn.com" },
                    { new Guid("47733c06-0193-4c85-a9f9-a6155cf6ede9"), new Guid("7f8c207e-2e58-48ef-a109-8aced3a0384f"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6968), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Plastic Computer", "added", "6410275666469", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://kira.org" },
                    { new Guid("4d044ef5-8d71-47b2-8095-4a1a65e9f0a4"), new Guid("9a06c1dd-b246-4c95-a570-0edbd496a69a"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(5627), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Granite Salad", "added", "9576846097210", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://amos.name" },
                    { new Guid("4d374591-d5ee-4a95-ad43-2321bd3aeb9c"), new Guid("e6acfc95-4ed3-4ed8-bba5-3b8dbc1afe20"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6404), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Granite Ball", "added", "1936719722874", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://zachery.org" },
                    { new Guid("5674f136-8197-497d-a469-9899e6c1a490"), new Guid("e6acfc95-4ed3-4ed8-bba5-3b8dbc1afe20"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7367), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Cotton Chips", "added", "6678811509896", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://edgardo.org" },
                    { new Guid("60fa8466-82c1-46e4-8759-748c8c3f78be"), new Guid("645648a5-69ee-4494-bd3c-f7ff58e798ca"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7412), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Fresh Sausages", "added", "1292933088531", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://ayden.org" },
                    { new Guid("614d2053-1c6c-4828-b4c6-03d419cdfc4f"), new Guid("7145b74f-6789-48ea-9363-d01074fb65b5"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7012), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Frozen Keyboard", "added", "9526809231427", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://heidi.net" },
                    { new Guid("644cc614-a7d0-448c-a622-1350091b4eba"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6921), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Metal Mouse", "added", "8597200257560", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://amie.name" },
                    { new Guid("6d454bb2-4087-427b-bfa6-90d06cf324d3"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6743), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Soft Cheese", "added", "0906042053663", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://alphonso.name" },
                    { new Guid("749dfe35-22e4-452d-a52a-dcaffc124d42"), new Guid("e0672d1b-4077-482d-98b4-e95d4aaf3a81"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6357), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Plastic Bike", "added", "2282687850385", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://melody.net" },
                    { new Guid("7d2a9097-f10c-4d9c-afe6-bce66434edc2"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6301), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Granite Sausages", "added", "6414281869517", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://myrl.biz" },
                    { new Guid("86a76497-8a4a-4f26-aad2-ffae59df0132"), new Guid("e6acfc95-4ed3-4ed8-bba5-3b8dbc1afe20"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8022), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Steel Salad", "added", "8204389640044", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://luella.info" },
                    { new Guid("89307360-e1d2-4bb9-9170-96e169f8954d"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6492), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Steel Mouse", "added", "4559156554500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://jaylen.name" },
                    { new Guid("8c585822-143d-4bb4-b093-4867411a5464"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6221), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Frozen Hat", "added", "1954375614173", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://alexys.org" },
                    { new Guid("94db3fe8-5793-4e67-b023-fd93d1d20ea4"), new Guid("7145b74f-6789-48ea-9363-d01074fb65b5"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7764), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Frozen Ball", "added", "1935714308076", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kitty.info" },
                    { new Guid("9e03e708-ae37-49eb-afdc-43dc91c47480"), new Guid("9a06c1dd-b246-4c95-a570-0edbd496a69a"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7630), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Soft Fish", "added", "3893934566547", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://connor.biz" },
                    { new Guid("9e529494-5176-46dd-8b50-cc55d77c4a8d"), new Guid("7145b74f-6789-48ea-9363-d01074fb65b5"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8698), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Metal Ball", "added", "6783595889734", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://nedra.info" },
                    { new Guid("a6248778-fed2-4b01-b479-4de733014c6b"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8266), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generic Granite Ball", "added", "2923353734065", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://leland.biz" },
                    { new Guid("a7cd6192-5e1e-417d-89d2-15390a144901"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6696), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Rubber Shoes", "added", "0698719828994", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://ubaldo.com" },
                    { new Guid("a8dad9f9-dfa3-4bc8-8eed-8f53f4fd8494"), new Guid("48537adc-4408-4c6f-af02-c48e4c1762e6"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8308), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gorgeous Plastic Salad", "added", "8559895909339", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://adriel.com" },
                    { new Guid("aafba511-7b95-42c2-9b0a-4201cec2d8d5"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7232), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Plastic Ball", "added", "6962729415517", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://daphne.name" },
                    { new Guid("ac4cda7e-04af-472d-a8dd-b69dab9793b2"), new Guid("e0672d1b-4077-482d-98b4-e95d4aaf3a81"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7541), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generic Granite Cheese", "added", "2936020335557", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://garrett.biz" },
                    { new Guid("aeacabfd-4108-4a25-9b6a-a90ef1713327"), new Guid("645648a5-69ee-4494-bd3c-f7ff58e798ca"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7321), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Steel Towels", "added", "4478365849750", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://dusty.net" },
                    { new Guid("b3022b16-1c6a-4ffe-b21e-9a676e01c3e2"), new Guid("e6acfc95-4ed3-4ed8-bba5-3b8dbc1afe20"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8655), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licensed Plastic Bike", "added", "5130148524658", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://eloisa.com" },
                    { new Guid("b9277744-92ba-4d33-8fe2-2c2a16403371"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7675), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licensed Metal Ball", "added", "0475262519797", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://fleta.info" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "Tag", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { new Guid("bac72417-8bd2-4199-bf6f-ecdd7befded6"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(8221), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Fresh Ball", "added", "3110965368811", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://evert.name" },
                    { new Guid("c06fead6-0f2b-4de4-bf74-d87fbdbae060"), new Guid("21159e48-34b0-4312-ae46-d8d959a9f4e4"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6786), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Plastic Tuna", "added", "9033617376535", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://adolf.net" },
                    { new Guid("c0ec624a-824b-4f1a-a4d4-62e77762dcb2"), new Guid("ce9c3933-d0fc-410e-8132-a9dc1e26a965"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7717), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Wooden Bacon", "added", "4913839374012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://chanelle.name" },
                    { new Guid("c60b4f65-4639-4fe0-851b-9e176e4df592"), new Guid("48537adc-4408-4c6f-af02-c48e4c1762e6"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6872), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Concrete Pants", "added", "1009670987450", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://name.com" },
                    { new Guid("cc5b60fd-bed9-4cdf-aa7d-68ee5fd3512d"), new Guid("645648a5-69ee-4494-bd3c-f7ff58e798ca"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6554), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Metal Pants", "added", "4079254969698", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://shanie.com" },
                    { new Guid("cd4b7a1c-f163-41a5-b851-a7d2594d02a3"), new Guid("41895378-3d39-4fe8-8533-df5fd1aa6ebb"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7454), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Concrete Chips", "added", "8272757901370", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://nicklaus.net" },
                    { new Guid("f720db3e-8c50-4bbe-9465-663583bb22d8"), new Guid("48537adc-4408-4c6f-af02-c48e4c1762e6"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(6603), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gorgeous Metal Towels", "added", "7937545162654", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://hardy.name" },
                    { new Guid("fbf057f7-a030-4962-a53d-50b9eb95d3b5"), new Guid("48537adc-4408-4c6f-af02-c48e4c1762e6"), new DateTime(2023, 6, 2, 16, 34, 20, 26, DateTimeKind.Utc).AddTicks(7100), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Fresh Chips", "added", "9641799918834", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://cortney.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                schema: "dbo",
                table: "Category",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "dbo",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Status",
                schema: "dbo",
                table: "Category",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                schema: "dbo",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                schema: "dbo",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Status",
                schema: "dbo",
                table: "Product",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "dbo",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "dbo",
                table: "User",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Status",
                schema: "dbo",
                table: "User",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
