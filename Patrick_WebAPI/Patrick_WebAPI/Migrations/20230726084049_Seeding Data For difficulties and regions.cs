using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patrick_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataFordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
