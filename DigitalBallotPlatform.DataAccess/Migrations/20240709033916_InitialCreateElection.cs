using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalBallotPlatform.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateElection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    IsSameAsBilling = table.Column<bool>(type: "bit", nullable: false),
                    ShpAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShpAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShpCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShpState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShpZipcode = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CountyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatermarkColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasHeaderFill = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatermarkColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watermarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watermarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BallotTabulation = table.Column<byte>(type: "tinyint", nullable: false),
                    VoterReg = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counties_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BallotMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    IsTextWeight = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallotMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BallotMaterials_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CompanyModelId = table.Column<int>(type: "int", nullable: true),
                    CountyModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Companies_CompanyModelId",
                        column: x => x.CompanyModelId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Counties_CountyModelId",
                        column: x => x.CountyModelId,
                        principalTable: "Counties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BallotSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    StubSize = table.Column<float>(type: "real", nullable: false),
                    IsTopStub = table.Column<bool>(type: "bit", nullable: false),
                    IsDuplex = table.Column<bool>(type: "bit", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    BallotMaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallotSpecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BallotSpecs_BallotMaterials_BallotMaterialId",
                        column: x => x.BallotMaterialId,
                        principalTable: "BallotMaterials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlatformUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecodaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountyId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlatformUsers_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlatformUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BallotCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    SubCategory = table.Column<byte>(type: "tinyint", nullable: true),
                    LARotation = table.Column<byte>(type: "tinyint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTestdeck = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    BallotSpecId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BallotCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BallotCategories_BallotSpecs_BallotSpecId",
                        column: x => x.BallotSpecId,
                        principalTable: "BallotSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectionSetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatermarkId = table.Column<int>(type: "int", nullable: true),
                    CountyId = table.Column<int>(type: "int", nullable: false),
                    BallotSpecsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionSetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectionSetups_BallotSpecs_BallotSpecsId",
                        column: x => x.BallotSpecsId,
                        principalTable: "BallotSpecs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionSetups_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionSetups_Watermarks_WatermarkId",
                        column: x => x.WatermarkId,
                        principalTable: "Watermarks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    WatermarkColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_ElectionSetups_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "ElectionSetups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parties_WatermarkColors_WatermarkColorId",
                        column: x => x.WatermarkColorId,
                        principalTable: "WatermarkColors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "CompanyId", "CountyId", "IsSameAsBilling", "ShpAddress1", "ShpAddress2", "ShpCity", "ShpState", "ShpZipcode", "State", "Zipcode" },
                values: new object[,]
                {
                    { -2, "7632 SE Douglas Ave", null, "Snoqualmie", null, -2, false, "11310 S Lake Stevens Rd", null, "Lake Stevens", "WA", 98258, "Washington", 98065 },
                    { -1, "11310 S Lake Stevens Rd", null, "Lake Stevens", -1, null, true, null, null, null, null, null, "Washington", 98258 }
                });

            migrationBuilder.InsertData(
                table: "BallotSpecs",
                columns: new[] { "Id", "BallotMaterialId", "IsDuplex", "IsTopStub", "Length", "MaterialId", "Pages", "StubSize", "Width" },
                values: new object[,]
                {
                    { -2, null, false, true, 14f, -1, 2, 1f, 8.5f },
                    { -1, null, false, true, 11f, -2, 1, 1f, 8.5f }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CompanyModelId", "CountyModelId", "Description", "Enabled", "Role" },
                values: new object[,]
                {
                    { -2, null, null, "Contributor", true, 1 },
                    { -1, null, null, "Admin", true, 0 }
                });

            migrationBuilder.InsertData(
                table: "WatermarkColors",
                columns: new[] { "Id", "Color", "HasHeaderFill", "Tint" },
                values: new object[,]
                {
                    { -3, "Brown", true, "465" },
                    { -2, "Blue", false, "543" },
                    { -1, "Orange", true, "151" }
                });

            migrationBuilder.InsertData(
                table: "Watermarks",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { -2, "", "CASeal" },
                    { -1, "", "CAOutline" }
                });

            migrationBuilder.InsertData(
                table: "BallotCategories",
                columns: new[] { "Id", "BallotSpecId", "Category", "Description", "Enabled", "IsTestdeck", "LARotation", "SubCategory" },
                values: new object[,]
                {
                    { -2, -1, (byte)4, "Absentee Ballot", false, false, null, null },
                    { -1, -2, (byte)5, "Poll Ballot", false, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressId", "ContactPerson", "CreatedAt", "Description", "Name" },
                values: new object[] { -1, -1, null, new DateTime(2024, 7, 8, 20, 39, 15, 625, DateTimeKind.Local).AddTicks(7777), null, "Roland" });

            migrationBuilder.InsertData(
                table: "Counties",
                columns: new[] { "Id", "AddressId", "BallotTabulation", "Name", "VoterReg" },
                values: new object[] { -1, -2, (byte)2, "King County Elections", (byte)5 });

            migrationBuilder.InsertData(
                table: "PlatformUsers",
                columns: new[] { "Id", "CompanyId", "CountyId", "CreatedAt", "Email", "Fullname", "Password", "PrimaryPhone", "RoleId", "SecodaryPhone", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("17866020-af79-4746-a98c-35f117c8d6dc"), null, null, new DateTime(2024, 7, 8, 20, 39, 15, 625, DateTimeKind.Local).AddTicks(8216), "cuggle1008@gmail.com", "Kathleen Lordan-Morris", "5p3ctrum", "4258022164", -2, null, null, "K-rad" },
                    { new Guid("ba77670b-4254-4311-99de-6821ab8cb99f"), null, null, new DateTime(2024, 7, 8, 20, 39, 15, 625, DateTimeKind.Local).AddTicks(8204), "jjelder79@gmail.com", "Justin Elder", "5p3ctrum", "4259234362", -1, null, null, "Guose" }
                });

            migrationBuilder.InsertData(
                table: "BallotMaterials",
                columns: new[] { "Id", "CompanyId", "IsTextWeight", "Weight" },
                values: new object[,]
                {
                    { -2, -1, false, 110 },
                    { -1, -1, true, 90 }
                });

            migrationBuilder.InsertData(
                table: "ElectionSetups",
                columns: new[] { "Id", "BallotSpecsId", "CountyId", "Description", "ElectionDate", "WatermarkId" },
                values: new object[] { -1, -2, -1, "General Election", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Abbreviations", "Acronym", "ElectionId", "Name", "WatermarkColorId" },
                values: new object[,]
                {
                    { -3, null, "LIB", -1, "Libertarian", null },
                    { -2, null, "DEM", -1, "Democrat", null },
                    { -1, null, "REP", -1, "Republican", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BallotCategories_BallotSpecId",
                table: "BallotCategories",
                column: "BallotSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_BallotMaterials_CompanyId",
                table: "BallotMaterials",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BallotSpecs_BallotMaterialId",
                table: "BallotSpecs",
                column: "BallotMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counties_AddressId",
                table: "Counties",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectionSetups_BallotSpecsId",
                table: "ElectionSetups",
                column: "BallotSpecsId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionSetups_CountyId",
                table: "ElectionSetups",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionSetups_WatermarkId",
                table: "ElectionSetups",
                column: "WatermarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_ElectionId",
                table: "Parties",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_WatermarkColorId",
                table: "Parties",
                column: "WatermarkColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformUsers_CompanyId",
                table: "PlatformUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformUsers_CountyId",
                table: "PlatformUsers",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformUsers_RoleId",
                table: "PlatformUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CompanyModelId",
                table: "Roles",
                column: "CompanyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CountyModelId",
                table: "Roles",
                column: "CountyModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BallotCategories");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "PlatformUsers");

            migrationBuilder.DropTable(
                name: "ElectionSetups");

            migrationBuilder.DropTable(
                name: "WatermarkColors");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BallotSpecs");

            migrationBuilder.DropTable(
                name: "Watermarks");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "BallotMaterials");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
