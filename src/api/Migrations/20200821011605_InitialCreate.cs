using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DefinitiveEdition.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsoleDeveloper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleDeveloper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConsole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(nullable: false),
                    ConsoleDeveloperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameConsole_ConsoleDeveloper_ConsoleDeveloperId",
                        column: x => x.ConsoleDeveloperId,
                        principalTable: "ConsoleDeveloper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(nullable: false),
                    SeriesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePort",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsInitialRelease = table.Column<bool>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    IsSameName = table.Column<bool>(nullable: false),
                    PortName = table.Column<string>(nullable: true),
                    GameId = table.Column<Guid>(nullable: false),
                    GameConsoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePort", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePort_GameConsole_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePort_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Feature = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GamePortId = table.Column<Guid>(nullable: false),
                    FeatureTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortFeature_FeatureType_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "FeatureType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortFeature_GamePort_GamePortId",
                        column: x => x.GamePortId,
                        principalTable: "GamePort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConsoleDeveloper",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nintendo" });

            migrationBuilder.InsertData(
                table: "FeatureType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pro" },
                    { 2, "Neutral" },
                    { 3, "Con" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "InitialReleaseDate", "Name" },
                values: new object[] { new Guid("1af5b35c-4c32-4a5d-ab3a-daeb5ec78e21"), "Save the Princess and Hyrule from Ganon sometimes. Fix me up later....", new DateTime(1986, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "InitialReleaseDate", "Name", "SeriesId" },
                values: new object[] { new Guid("ccf277b7-b189-448a-9468-70105aaa7fc8"), new DateTime(2000, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda - Majora's Mask", new Guid("1af5b35c-4c32-4a5d-ab3a-daeb5ec78e21") });

            migrationBuilder.InsertData(
                table: "GameConsole",
                columns: new[] { "Id", "ConsoleDeveloperId", "InitialReleaseDate", "Name" },
                values: new object[] { new Guid("e6ac0412-b8d0-43ce-8d3a-b3d80f70db75"), 1, new DateTime(2011, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3DS" });

            migrationBuilder.InsertData(
                table: "GameConsole",
                columns: new[] { "Id", "ConsoleDeveloperId", "InitialReleaseDate", "Name" },
                values: new object[] { new Guid("9fc6465c-c8c4-4496-9040-d5faa7ce71a2"), 1, new DateTime(1996, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "64" });

            migrationBuilder.InsertData(
                table: "GamePort",
                columns: new[] { "Id", "GameConsoleId", "GameId", "IsInitialRelease", "IsSameName", "PortName", "ReleaseDate" },
                values: new object[] { new Guid("fdb1993e-bca6-4961-9426-18a8f680c730"), new Guid("9fc6465c-c8c4-4496-9040-d5faa7ce71a2"), new Guid("ccf277b7-b189-448a-9468-70105aaa7fc8"), true, true, null, null });

            migrationBuilder.InsertData(
                table: "GamePort",
                columns: new[] { "Id", "GameConsoleId", "GameId", "IsInitialRelease", "IsSameName", "PortName", "ReleaseDate" },
                values: new object[] { new Guid("ef2d234e-e70f-400b-850a-2d460129e563"), new Guid("e6ac0412-b8d0-43ce-8d3a-b3d80f70db75"), new Guid("ccf277b7-b189-448a-9468-70105aaa7fc8"), false, false, "The Legend of Zelda - Majora's Mask 3D", new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PortFeature",
                columns: new[] { "Id", "Description", "Feature", "FeatureTypeId", "GamePortId" },
                values: new object[,]
                {
                    { new Guid("bbb679fc-0941-4b76-b596-7c12420c4896"), "Swimming speed while wearing the Zora mask is automatically fast without needing to use magic", "Fast Zora Swimming", 1, new Guid("fdb1993e-bca6-4961-9426-18a8f680c730") },
                    { new Guid("5fd825af-56cf-4343-81ee-f4372f2c38a1"), "The original release of Majora's Mask capped out at a framerate of 20 FPS. Little hard on the eyes at first", "20 FPS", 3, new Guid("fdb1993e-bca6-4961-9426-18a8f680c730") },
                    { new Guid("0c66e103-39d1-4c84-87d8-7cb71d597ada"), "The 3DS port runs a bit smoother at 30 FPS, which is easier on the eyes", "30 FPS", 1, new Guid("ef2d234e-e70f-400b-850a-2d460129e563") },
                    { new Guid("7b46ba9c-52e2-4ec8-a971-14e7bb8c22f7"), "Some purists may complain that this takes away from the original, the Song of Double Time can take you to a specific time of the current day you are on.", "Improved Song of Double Time", 2, new Guid("ef2d234e-e70f-400b-850a-2d460129e563") },
                    { new Guid("e43a0874-843f-4a7b-a5b8-62aa06cb7770"), "Without using Magic, the Zora swimming speed will seem like you are crawling through the ocean. Fan patches have been made to patch this though", "Slow Zora Swimming", 3, new Guid("ef2d234e-e70f-400b-850a-2d460129e563") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_SeriesId",
                table: "Game",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsole_ConsoleDeveloperId",
                table: "GameConsole",
                column: "ConsoleDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePort_GameConsoleId",
                table: "GamePort",
                column: "GameConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePort_GameId",
                table: "GamePort",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PortFeature_FeatureTypeId",
                table: "PortFeature",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortFeature_GamePortId",
                table: "PortFeature",
                column: "GamePortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortFeature");

            migrationBuilder.DropTable(
                name: "FeatureType");

            migrationBuilder.DropTable(
                name: "GamePort");

            migrationBuilder.DropTable(
                name: "GameConsole");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "ConsoleDeveloper");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
