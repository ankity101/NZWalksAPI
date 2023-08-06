using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patrick_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3dd5832e-3486-48cf-b65f-dd1f437a06a1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d2c6f8cf-4b3b-467e-a329-6dba8ef8d789"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d35708cd-7600-419a-ace8-108378ff52b3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("195c66f8-2f06-4afb-9db6-6cf646e18a67"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4f892c30-4271-4817-8310-99d631f6c1cb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8b2171f2-5c23-4d75-93af-c6529ef2cbbf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b9151fc1-3927-48e9-a4c7-5d2761c8b629"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e3ce7ea7-a5a3-4236-8160-7b076dc89026"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fdd46876-4630-499c-93f8-8f02b55dc14b"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("be387e06-4035-4ef6-83a2-61616d27987c"), "Easy" },
                    { new Guid("c68a28a2-fa36-49eb-8b36-cffa28d8c1f1"), "Hard" },
                    { new Guid("cb1e165d-6282-444e-a832-23e089fef7d4"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("a5393b9f-2b9e-4b22-ad28-d27b7fc024b8"), "GUM", "Gurugram", "image-Gurugram.jpg" },
                    { new Guid("a6c0aa6d-02a7-4f76-8546-daf0614b4b2e"), "VNS", "Varansi", "image-vns.jpg" },
                    { new Guid("b74a307d-9bca-4f6d-8cba-78e97b5aca8c"), "CHEN", "Chennai", "image-Chennai.jpg" },
                    { new Guid("e11ed2f1-4b20-49eb-8b52-7b1fcf259b5a"), "DEL", "Delhi", "image-del.jpg" },
                    { new Guid("e1b0d45a-107b-456c-9339-19efcb27ad1f"), "HYD", "Hydarabad", "image-hyd.jpg" },
                    { new Guid("fc327605-b0e3-48aa-903e-3535536b08e9"), "MUM", "Mumbai", "image-mum.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "ID", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[] { new Guid("4e752299-0451-4070-b229-511318eb29e8"), "this is dummy Walk", new Guid("da2bf721-fe71-45e9-b4ea-4469cf877a1d"), 1.0, "Dummmy-Walk", new Guid("a2d6b4f0-71cf-4507-93f5-efcec2c90116"), "Imge-dummy.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("be387e06-4035-4ef6-83a2-61616d27987c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c68a28a2-fa36-49eb-8b36-cffa28d8c1f1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cb1e165d-6282-444e-a832-23e089fef7d4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5393b9f-2b9e-4b22-ad28-d27b7fc024b8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a6c0aa6d-02a7-4f76-8546-daf0614b4b2e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b74a307d-9bca-4f6d-8cba-78e97b5aca8c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e11ed2f1-4b20-49eb-8b52-7b1fcf259b5a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e1b0d45a-107b-456c-9339-19efcb27ad1f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fc327605-b0e3-48aa-903e-3535536b08e9"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "ID",
                keyValue: new Guid("4e752299-0451-4070-b229-511318eb29e8"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3dd5832e-3486-48cf-b65f-dd1f437a06a1"), "Medium" },
                    { new Guid("d2c6f8cf-4b3b-467e-a329-6dba8ef8d789"), "Easy" },
                    { new Guid("d35708cd-7600-419a-ace8-108378ff52b3"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("195c66f8-2f06-4afb-9db6-6cf646e18a67"), "MUM", "Mumbai", "image-mum.jpg" },
                    { new Guid("4f892c30-4271-4817-8310-99d631f6c1cb"), "HYD", "Hydarabad", "image-hyd.jpg" },
                    { new Guid("8b2171f2-5c23-4d75-93af-c6529ef2cbbf"), "DEL", "Delhi", "image-del.jpg" },
                    { new Guid("b9151fc1-3927-48e9-a4c7-5d2761c8b629"), "VNS", "Varansi", "image-vns.jpg" },
                    { new Guid("e3ce7ea7-a5a3-4236-8160-7b076dc89026"), "GUM", "Gurugram", "image-Gurugram.jpg" },
                    { new Guid("fdd46876-4630-499c-93f8-8f02b55dc14b"), "CHEN", "Chennai", "image-Chennai.jpg" }
                });
        }
    }
}
