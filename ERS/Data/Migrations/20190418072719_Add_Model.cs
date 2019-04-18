using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ERS.Data.Migrations
{
    public partial class Add_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upazilas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazilas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESSInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ESSCode = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    WorkingArea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESSInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ESSInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    TemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTemplates_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmpDistrictMaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictId = table.Column<int>(nullable: false),
                    ESSInfoId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDistrictMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpDistrictMaps_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpDistrictMaps_ESSInfos_ESSInfoId",
                        column: x => x.ESSInfoId,
                        principalTable: "ESSInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpDistrictMaps_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmpDivisionMaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionId = table.Column<int>(nullable: false),
                    ESSInfoId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDivisionMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpDivisionMaps_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpDivisionMaps_ESSInfos_ESSInfoId",
                        column: x => x.ESSInfoId,
                        principalTable: "ESSInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpDivisionMaps_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmpProductMaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ESSInfoId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProductMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpProductMaps_ESSInfos_ESSInfoId",
                        column: x => x.ESSInfoId,
                        principalTable: "ESSInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpProductMaps_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpProductMaps_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmpUpazilaMaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ESSInfoId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    UpazilaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpUpazilaMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpUpazilaMaps_ESSInfos_ESSInfoId",
                        column: x => x.ESSInfoId,
                        principalTable: "ESSInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpUpazilaMaps_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpUpazilaMaps_Upazilas_UpazilaId",
                        column: x => x.UpazilaId,
                        principalTable: "Upazilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpDistrictMaps_DistrictId",
                table: "EmpDistrictMaps",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDistrictMaps_ESSInfoId",
                table: "EmpDistrictMaps",
                column: "ESSInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDistrictMaps_EmployeeId",
                table: "EmpDistrictMaps",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDivisionMaps_DivisionId",
                table: "EmpDivisionMaps",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDivisionMaps_ESSInfoId",
                table: "EmpDivisionMaps",
                column: "ESSInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDivisionMaps_EmployeeId",
                table: "EmpDivisionMaps",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProductMaps_ESSInfoId",
                table: "EmpProductMaps",
                column: "ESSInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProductMaps_EmployeeId",
                table: "EmpProductMaps",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProductMaps_ProductId",
                table: "EmpProductMaps",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpUpazilaMaps_ESSInfoId",
                table: "EmpUpazilaMaps",
                column: "ESSInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpUpazilaMaps_EmployeeId",
                table: "EmpUpazilaMaps",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpUpazilaMaps_UpazilaId",
                table: "EmpUpazilaMaps",
                column: "UpazilaId");

            migrationBuilder.CreateIndex(
                name: "IX_ESSInfos_EmployeeId",
                table: "ESSInfos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTemplates_ProductId",
                table: "ProductTemplates",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpDistrictMaps");

            migrationBuilder.DropTable(
                name: "EmpDivisionMaps");

            migrationBuilder.DropTable(
                name: "EmpProductMaps");

            migrationBuilder.DropTable(
                name: "EmpUpazilaMaps");

            migrationBuilder.DropTable(
                name: "ProductTemplates");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "ESSInfos");

            migrationBuilder.DropTable(
                name: "Upazilas");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
