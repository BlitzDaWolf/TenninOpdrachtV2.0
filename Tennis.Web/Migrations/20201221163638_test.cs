using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tennis.Web.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_league", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FederationNr = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(35)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(70)", nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(6)", nullable: false),
                    Addition = table.Column<string>(type: "VARCHAR(2)", nullable: true),
                    Zipcode = table.Column<string>(type: "VARCHAR(6)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    PhoneNr = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_member_tbl_gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "tbl_gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_fine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FineNumber = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(7,2)", nullable: false),
                    handOutDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_fine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_fine_tbl_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "tbl_member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameNumber = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_game_tbl_league_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "tbl_league",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_game_tbl_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "tbl_member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_member_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_member_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_member_role_tbl_member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "tbl_member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_member_role_tbl_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_game_result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SetNr = table.Column<int>(type: "INT", maxLength: 3, nullable: false),
                    ScoreTeamMember = table.Column<int>(type: "INT", maxLength: 3, nullable: false),
                    ScoreOpponent = table.Column<int>(type: "INT", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_game_result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_game_result_tbl_game_GameId",
                        column: x => x.GameId,
                        principalTable: "tbl_game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "tbl_league",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Junoir" },
                    { 2, "Pro" }
                });

            migrationBuilder.InsertData(
                table: "tbl_role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_fine_FineNumber",
                table: "tbl_fine",
                column: "FineNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_fine_MemberId",
                table: "tbl_fine",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_game_GameNumber",
                table: "tbl_game",
                column: "GameNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_game_LeagueId",
                table: "tbl_game",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_game_MemberId",
                table: "tbl_game",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_game_result_GameId",
                table: "tbl_game_result",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_game_result_SetNr_GameId",
                table: "tbl_game_result",
                columns: new[] { "SetNr", "GameId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_gender_Name",
                table: "tbl_gender",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_league_Name",
                table: "tbl_league",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_member_FederationNr",
                table: "tbl_member",
                column: "FederationNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_member_GenderId",
                table: "tbl_member",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_member_role_MemberId_RoleId_StartDate_EndDate",
                table: "tbl_member_role",
                columns: new[] { "MemberId", "RoleId", "StartDate", "EndDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_member_role_RoleId",
                table: "tbl_member_role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_Name",
                table: "tbl_role",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_fine");

            migrationBuilder.DropTable(
                name: "tbl_game_result");

            migrationBuilder.DropTable(
                name: "tbl_member_role");

            migrationBuilder.DropTable(
                name: "tbl_game");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_league");

            migrationBuilder.DropTable(
                name: "tbl_member");

            migrationBuilder.DropTable(
                name: "tbl_gender");
        }
    }
}
