using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpraApi.Persistance.Migrations
{
    public partial class mig1 : Migration
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordRetryCount = table.Column<int>(type: "integer", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Role = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Url = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Tag = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    { new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4821), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sports", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4129), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Games", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("3434d6e3-9e09-4a0e-8cfc-db303f22bb48"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4690), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Outdoors", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("36a4ff40-013b-4be3-ade7-c0aac4f2b8a4"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4809), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Books", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("3c544090-0835-4a05-b116-a62e5eddd57f"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4800), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Toys", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("82a5e90d-a08c-430e-a04d-df0dee8bf17e"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4649), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shoes", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4668), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Garden", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("b3787a64-206d-40c0-a677-3852dd9f9ba3"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4680), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kids", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("ba920d3f-56a1-45f3-b9cf-9c0d0a87669e"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4777), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industrial", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("c7d60216-04d6-45eb-9dce-50a247842e59"), new DateTime(2023, 6, 1, 11, 0, 38, 937, DateTimeKind.Utc).AddTicks(4790), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tools", "added", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastActivity", "LastName", "Password", "PasswordRetryCount", "Role", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("f2429a8a-a58c-4f0b-9874-ae9c8b6ba1ed"), new DateTime(2023, 6, 1, 11, 0, 38, 944, DateTimeKind.Utc).AddTicks(9783), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@simpra.com", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new byte[] { 140, 105, 118, 229, 181, 65, 4, 21, 189, 233, 8, 189, 77, 238, 21, 223, 177, 103, 169, 200, 115, 252, 75, 184, 168, 31, 111, 42, 180, 72, 169, 24 }, 0, "admin", "active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "Status", "Tag", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { new Guid("05861dae-2ee5-4356-aac6-6b03197055e3"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2553), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Rubber Soap", "added", "9720759112038", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://gillian.name" },
                    { new Guid("05ac380a-9afb-408d-a466-bc557b8ff068"), new Guid("ba920d3f-56a1-45f3-b9cf-9c0d0a87669e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3171), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Metal Towels", "added", "2149179200236", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://hermina.org" },
                    { new Guid("06cdf3a0-8db1-4632-9a52-d00f307f76fd"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3477), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Plastic Sausages", "added", "8940767237528", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://gabriel.biz" },
                    { new Guid("0d3adc1a-3a15-4ae4-9bdb-93ef41b1d058"), new Guid("36a4ff40-013b-4be3-ade7-c0aac4f2b8a4"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4327), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Steel Hat", "added", "1385410514606", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://ahmed.net" },
                    { new Guid("0e1ffb65-ae28-46ae-a35f-00ced8dd29f0"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2768), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Concrete Pizza", "added", "3118809384744", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kristoffer.net" },
                    { new Guid("11728d5a-d461-448a-9b29-0a676bd2c785"), new Guid("36a4ff40-013b-4be3-ade7-c0aac4f2b8a4"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3563), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Rubber Table", "added", "4672875155961", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kay.info" },
                    { new Guid("13164e36-a80d-4006-9474-32026098d36f"), new Guid("3c544090-0835-4a05-b116-a62e5eddd57f"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3221), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Rubber Table", "added", "9550532792399", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://hillary.name" },
                    { new Guid("153fa0aa-5cc5-450b-a064-cf5c072f2b6d"), new Guid("3c544090-0835-4a05-b116-a62e5eddd57f"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2822), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Cotton Computer", "added", "1657338706549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://naomi.name" },
                    { new Guid("162d35f1-31e1-47fa-9ab2-eaf8267a6ca8"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2058), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Granite Chips", "added", "5567101835931", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://arnold.net" },
                    { new Guid("186084da-a820-47ee-8ed4-06a2de2d21ad"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4551), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Rubber Chips", "added", "2712850646137", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://celestine.biz" },
                    { new Guid("22230984-97d5-4ebf-8925-0e5d7854e263"), new Guid("b3787a64-206d-40c0-a677-3852dd9f9ba3"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3127), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Fresh Shoes", "added", "8800376689500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://rubye.net" },
                    { new Guid("2b01e0bb-8e7f-4e1f-8076-c71d6e9a48dd"), new Guid("3434d6e3-9e09-4a0e-8cfc-db303f22bb48"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3910), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Wooden Towels", "added", "5995063525506", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://abbigail.info" },
                    { new Guid("2b8adbf5-f2b6-4a0c-ad96-ee822c45f888"), new Guid("36a4ff40-013b-4be3-ade7-c0aac4f2b8a4"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2597), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Cotton Sausages", "added", "1617952992858", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://brenna.info" },
                    { new Guid("2f73f77e-8f3a-4573-92b1-0afa45ae7940"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3732), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Small Plastic Ball", "added", "3231030376163", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kiarra.org" },
                    { new Guid("3b949ed2-9106-447b-a82e-5e30c83b09d3"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2456), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Soft Fish", "added", "8278757602187", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://collin.org" },
                    { new Guid("49c6cf29-1a28-4ce9-9338-37c43eff09b9"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2683), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gorgeous Concrete Car", "added", "5728384315446", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://rene.com" },
                    { new Guid("5484e15d-2cf3-44b0-829e-a77d89838995"), new Guid("36a4ff40-013b-4be3-ade7-c0aac4f2b8a4"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2954), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Plastic Bike", "added", "7837489966670", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://concepcion.com" },
                    { new Guid("558913a5-80ed-4586-a66b-72965d634f03"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4112), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Concrete Keyboard", "added", "0787817778154", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://emily.org" },
                    { new Guid("566a38ba-dc27-4cd1-b1bd-e4580f906260"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3305), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Frozen Salad", "added", "0254524714930", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://berry.org" },
                    { new Guid("6308326f-e23c-4f5c-a6fe-733a861ad170"), new Guid("82a5e90d-a08c-430e-a04d-df0dee8bf17e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2910), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Wooden Ball", "added", "0551357600288", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://osvaldo.info" },
                    { new Guid("69e12d75-4ea7-4666-ba10-d1751414d19a"), new Guid("b3787a64-206d-40c0-a677-3852dd9f9ba3"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3040), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Concrete Chips", "added", "2455902107889", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://paris.net" },
                    { new Guid("6b760616-87d1-473c-bb37-43a5cb6bf1f0"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(1264), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Cotton Bike", "added", "0665226823729", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://jamir.name" },
                    { new Guid("6bb3a7ef-d305-44e5-8e4e-8d76280e2143"), new Guid("3c544090-0835-4a05-b116-a62e5eddd57f"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3432), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Plastic Chair", "added", "5295507660702", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://brant.net" },
                    { new Guid("6f383a40-19eb-4d1f-8a33-2b4517b3b99e"), new Guid("c7d60216-04d6-45eb-9dce-50a247842e59"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4504), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantastic Metal Salad", "added", "9584309446536", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://turner.com" },
                    { new Guid("71a6f34a-9031-46fd-9906-d5b892b219c5"), new Guid("ba920d3f-56a1-45f3-b9cf-9c0d0a87669e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4201), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Metal Keyboard", "added", "9830406819019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://hope.name" },
                    { new Guid("7237f793-958c-4355-8467-36ce27405977"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2318), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rustic Rubber Shoes", "added", "0584829455024", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://gaston.org" },
                    { new Guid("7b310c63-754e-424e-886a-b423798822ce"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3348), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licensed Steel Computer", "added", "7717636099171", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://clovis.com" },
                    { new Guid("862c20b1-1a27-4292-9f89-0cb6ed8219e0"), new Guid("c7d60216-04d6-45eb-9dce-50a247842e59"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4286), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Frozen Ball", "added", "8287777821164", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://rossie.info" },
                    { new Guid("8782867e-0529-4e28-b8ca-9ebf8dbd2484"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2510), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Soft Chips", "added", "3773308626339", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://darlene.name" },
                    { new Guid("8e6b60ea-4941-428b-96f0-fec3bb438956"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2640), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refined Plastic Chips", "added", "0016449091110", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://kaylah.com" },
                    { new Guid("980754e7-11eb-45fe-9c1e-45cf033bb828"), new Guid("ba920d3f-56a1-45f3-b9cf-9c0d0a87669e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3650), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generic Plastic Sausages", "added", "3600004838707", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://francisca.org" },
                    { new Guid("9d41c785-9c82-489d-939b-335b3c551455"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2867), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Wooden Bike", "added", "5904335763157", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://elvera.net" },
                    { new Guid("add0808c-1ef9-413b-9fe3-2f9e89fa5db9"), new Guid("36a4ff40-013b-4be3-ade7-c0aac4f2b8a4"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3608), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Concrete Tuna", "added", "7049457594376", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://elvera.biz" },
                    { new Guid("af67e60e-9493-4b12-b958-8402995c46d3"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4410), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Concrete Salad", "added", "2840361702025", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://eliseo.net" },
                    { new Guid("bd4fd02f-8a9a-4449-a75a-6a7e0b03afab"), new Guid("b3787a64-206d-40c0-a677-3852dd9f9ba3"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2218), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic Wooden Shoes", "added", "8440962140932", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://damion.net" },
                    { new Guid("be222974-26f2-4ce5-a3ba-9c5b12b74543"), new Guid("ba920d3f-56a1-45f3-b9cf-9c0d0a87669e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2167), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generic Fresh Hat", "added", "0531412637190", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://rebekah.name" },
                    { new Guid("c2b955d3-670b-43bc-93b5-a00ea7fae912"), new Guid("155d034b-7971-4b00-b06f-e6b25fb6308b"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3520), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Steel Car", "added", "6405390806289", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://evie.com" },
                    { new Guid("c4d2a232-318c-4cf8-a20f-f1288ffd0750"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4158), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Frozen Chicken", "added", "4387879413565", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://everette.net" },
                    { new Guid("cd2bf314-610b-42df-96d4-a2806a006ff5"), new Guid("82a5e90d-a08c-430e-a04d-df0dee8bf17e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4002), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Practical Granite Shoes", "added", "5067489769694", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://alaina.biz" },
                    { new Guid("d04e3063-1d64-4079-805a-988996d196a5"), new Guid("c7d60216-04d6-45eb-9dce-50a247842e59"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2265), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incredible Concrete Sausages", "added", "2953144852401", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://lori.org" },
                    { new Guid("e3437493-8bcc-4602-b11d-9991a07c8bff"), new Guid("07b9025b-0dc2-4a0f-b7ed-dba4649cd1c0"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4459), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unbranded Frozen Soap", "added", "8368232074056", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://phoebe.info" },
                    { new Guid("e4bc1c8e-e730-4990-b6b2-d6398de7540d"), new Guid("3434d6e3-9e09-4a0e-8cfc-db303f22bb48"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2117), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Steel Pants", "added", "1031280686522", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://devyn.org" },
                    { new Guid("e53f8890-392d-4318-b626-c584ae0068ae"), new Guid("3c544090-0835-4a05-b116-a62e5eddd57f"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3867), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Rubber Mouse", "added", "2524673101522", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kaylie.org" },
                    { new Guid("e6acc83f-e50a-449a-92fa-b99acf25c556"), new Guid("82a5e90d-a08c-430e-a04d-df0dee8bf17e"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3953), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sleek Cotton Pants", "added", "4331135388005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://kip.info" },
                    { new Guid("e7bf459d-ed87-4806-98f9-37c3544e94c7"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(2996), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent Metal Gloves", "added", "7459911408956", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://johnpaul.org" },
                    { new Guid("e95449ee-e81f-404b-bd08-0c837e9e8226"), new Guid("c7d60216-04d6-45eb-9dce-50a247842e59"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3263), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handmade Cotton Chair", "added", "0506061308883", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://trevion.net" },
                    { new Guid("e97c67bb-4e5e-42fd-84d0-1b87e1cad3e3"), new Guid("c7d60216-04d6-45eb-9dce-50a247842e59"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3779), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awesome Plastic Cheese", "added", "7535127997146", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://river.org" },
                    { new Guid("f02847f8-c718-4851-9420-c0c6ecf52c22"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(4243), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licensed Concrete Hat", "added", "7189905579262", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://darius.info" },
                    { new Guid("f36cc540-0961-44ad-9dd3-0bbbcf90cdbb"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(1818), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasty Rubber Table", "added", "5885445599976", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://tabitha.com" },
                    { new Guid("f78b03f1-87ce-46b0-b117-abc0451d3264"), new Guid("b32b9929-605a-4019-b03d-46c783fb3837"), new DateTime(2023, 6, 1, 11, 0, 38, 940, DateTimeKind.Utc).AddTicks(3823), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Handcrafted Cotton Soap", "added", "2638520444295", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://audreanne.info" }
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
