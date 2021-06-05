using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetSystem.Migrations
{
    public partial class DBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompnayIndex = table.Column<byte>(type: "tinyint", nullable: false),
                    CompanyTiltle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeofRepairs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeofRepairs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasurements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID_FK = table.Column<int>(type: "int", nullable: false),
                    GroupIndex = table.Column<byte>(type: "tinyint", nullable: false),
                    GroupTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groups_Companies_CompanyID_FK",
                        column: x => x.CompanyID_FK,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID_FK = table.Column<int>(type: "int", nullable: false),
                    GroupID_FK = table.Column<int>(type: "int", nullable: false),
                    SubGroupIndex = table.Column<byte>(type: "tinyint", nullable: false),
                    SubGroupTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Registered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubGroups_Companies_CompanyID_FK",
                        column: x => x.CompanyID_FK,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubGroups_Groups_GroupID_FK",
                        column: x => x.GroupID_FK,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Codings",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID_FK = table.Column<int>(type: "int", nullable: false),
                    GroupID_FK = table.Column<int>(type: "int", nullable: false),
                    SubGroupID_FK = table.Column<int>(type: "int", nullable: false),
                    UserID_FK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeIndex = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CodeTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Codings_AspNetUsers_UserID_FK",
                        column: x => x.UserID_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Codings_Companies_CompanyID_FK",
                        column: x => x.CompanyID_FK,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Codings_Groups_GroupID_FK",
                        column: x => x.GroupID_FK,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Codings_SubGroups_SubGroupID_FK",
                        column: x => x.SubGroupID_FK,
                        principalTable: "SubGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machineries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CodeID_FK = table.Column<long>(type: "bigint", nullable: false),
                    MachineryTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machineries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Machineries_Codings_CodeID_FK",
                        column: x => x.CodeID_FK,
                        principalTable: "Codings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestRepairs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MachineryID_FK = table.Column<int>(type: "int", nullable: false),
                    UserID_FK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDataTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeofRepairID_FK = table.Column<int>(type: "int", nullable: false),
                    ApplicantID_FK = table.Column<int>(type: "int", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestRepairs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestRepairs_Applicants_ApplicantID_FK",
                        column: x => x.ApplicantID_FK,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestRepairs_AspNetUsers_UserID_FK",
                        column: x => x.UserID_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestRepairs_Machineries_MachineryID_FK",
                        column: x => x.MachineryID_FK,
                        principalTable: "Machineries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestRepairs_TypeofRepairs_TypeofRepairID_FK",
                        column: x => x.TypeofRepairID_FK,
                        principalTable: "TypeofRepairs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableParts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID_FK = table.Column<long>(type: "bigint", nullable: false),
                    ConsumablePartTitel = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    UnitID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableParts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsumableParts_RequestRepairs_RequestID_FK",
                        column: x => x.RequestID_FK,
                        principalTable: "RequestRepairs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumableParts_UnitOfMeasurements_UnitID_FK",
                        column: x => x.UnitID_FK,
                        principalTable: "UnitOfMeasurements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    RequestID_FK = table.Column<long>(type: "bigint", nullable: false),
                    Electrical = table.Column<bool>(type: "bit", nullable: false),
                    Mecanical = table.Column<bool>(type: "bit", nullable: false),
                    Piping = table.Column<bool>(type: "bit", nullable: false),
                    Creating = table.Column<bool>(type: "bit", nullable: false),
                    Equip = table.Column<bool>(type: "bit", nullable: false),
                    RepairOutside = table.Column<bool>(type: "bit", nullable: false),
                    RepairOutSideReportID_FK = table.Column<int>(type: "int", nullable: false),
                    StartWorking = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cause_Exhaustion = table.Column<bool>(type: "bit", nullable: false),
                    Cause_OperatorNegligence = table.Column<bool>(type: "bit", nullable: false),
                    Cause_QualityofSpareParts = table.Column<bool>(type: "bit", nullable: false),
                    Cause_RepairmanError = table.Column<bool>(type: "bit", nullable: false),
                    OtherError = table.Column<bool>(type: "bit", nullable: false),
                    OtherErrorDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReportRepair = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PersonHours = table.Column<bool>(type: "bit", nullable: false),
                    PersonHoursTime = table.Column<short>(type: "smallint", nullable: false),
                    PersonHoursDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductionPlanning = table.Column<bool>(type: "bit", nullable: false),
                    ProductionPlanningTime = table.Column<short>(type: "smallint", nullable: false),
                    ProductionPlanningDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NoSpareParts = table.Column<bool>(type: "bit", nullable: false),
                    NoSparePartsTime = table.Column<short>(type: "smallint", nullable: false),
                    NoSparePartsDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    OtherTime = table.Column<short>(type: "smallint", nullable: false),
                    OtherDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CloseRequest = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeClosing = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkOrders_RequestRepairs_RequestID_FK",
                        column: x => x.RequestID_FK,
                        principalTable: "RequestRepairs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Codings_CompanyID_FK",
                table: "Codings",
                column: "CompanyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Codings_GroupID_FK",
                table: "Codings",
                column: "GroupID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Codings_SubGroupID_FK",
                table: "Codings",
                column: "SubGroupID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Codings_UserID_FK",
                table: "Codings",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableParts_RequestID_FK",
                table: "ConsumableParts",
                column: "RequestID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableParts_UnitID_FK",
                table: "ConsumableParts",
                column: "UnitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CompanyID_FK",
                table: "Groups",
                column: "CompanyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Machineries_CodeID_FK",
                table: "Machineries",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRepairs_ApplicantID_FK",
                table: "RequestRepairs",
                column: "ApplicantID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRepairs_MachineryID_FK",
                table: "RequestRepairs",
                column: "MachineryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRepairs_TypeofRepairID_FK",
                table: "RequestRepairs",
                column: "TypeofRepairID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRepairs_UserID_FK",
                table: "RequestRepairs",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_CompanyID_FK",
                table: "SubGroups",
                column: "CompanyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_GroupID_FK",
                table: "SubGroups",
                column: "GroupID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_RequestID_FK",
                table: "WorkOrders",
                column: "RequestID_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConsumableParts");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UnitOfMeasurements");

            migrationBuilder.DropTable(
                name: "RequestRepairs");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Machineries");

            migrationBuilder.DropTable(
                name: "TypeofRepairs");

            migrationBuilder.DropTable(
                name: "Codings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
