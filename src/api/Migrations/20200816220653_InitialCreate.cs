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
                    ConsoleDeveloperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleDeveloper", x => x.ConsoleDeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "FeatureType",
                columns: table => new
                {
                    FeatureTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureType", x => x.FeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                });

            migrationBuilder.CreateTable(
                name: "GameConsole",
                columns: table => new
                {
                    GameConsoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(nullable: false),
                    ConsoleDeveloperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsole", x => x.GameConsoleId);
                    table.ForeignKey(
                        name: "FK_GameConsole_ConsoleDeveloper_ConsoleDeveloperId",
                        column: x => x.ConsoleDeveloperId,
                        principalTable: "ConsoleDeveloper",
                        principalColumn: "ConsoleDeveloperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(nullable: false),
                    SeriesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "SeriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePort",
                columns: table => new
                {
                    GamePortId = table.Column<Guid>(nullable: false),
                    IsInitialRelease = table.Column<bool>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    IsSameName = table.Column<bool>(nullable: false),
                    PortName = table.Column<string>(nullable: true),
                    GameId = table.Column<Guid>(nullable: false),
                    GameConsoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePort", x => x.GamePortId);
                    table.ForeignKey(
                        name: "FK_GamePort_GameConsole_GameConsoleId",
                        column: x => x.GameConsoleId,
                        principalTable: "GameConsole",
                        principalColumn: "GameConsoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePort_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortFeature",
                columns: table => new
                {
                    PortFeatureId = table.Column<Guid>(nullable: false),
                    Feature = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GameId = table.Column<Guid>(nullable: false),
                    GamePortId = table.Column<Guid>(nullable: false),
                    FeatureTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortFeature", x => x.PortFeatureId);
                    table.ForeignKey(
                        name: "FK_PortFeature_FeatureType_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "FeatureType",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortFeature_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortFeature_GamePort_GamePortId",
                        column: x => x.GamePortId,
                        principalTable: "GamePort",
                        principalColumn: "GamePortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConsoleDeveloper",
                columns: new[] { "ConsoleDeveloperId", "Name" },
                values: new object[] { 1, "Nintendo" });

            migrationBuilder.InsertData(
                table: "FeatureType",
                columns: new[] { "FeatureTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Pro" },
                    { 2, "Neutral" },
                    { 3, "Con" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "SeriesId", "Description", "InitialReleaseDate", "Name" },
                values: new object[] { new Guid("dd11a88d-3348-49e3-8fc2-fe018d940be3"), "Save the Princess and Hyrule from Ganon sometimes. Fix me up later....", new DateTime(1986, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameId", "InitialReleaseDate", "Name", "SeriesId" },
                values: new object[] { new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), new DateTime(2000, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda - Majora's Mask", new Guid("dd11a88d-3348-49e3-8fc2-fe018d940be3") });

            migrationBuilder.InsertData(
                table: "GameConsole",
                columns: new[] { "GameConsoleId", "ConsoleDeveloperId", "InitialReleaseDate", "Name" },
                values: new object[] { new Guid("3e4ed385-0e49-4758-ab38-86dae54eae63"), 1, new DateTime(2011, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3DS" });

            migrationBuilder.InsertData(
                table: "GameConsole",
                columns: new[] { "GameConsoleId", "ConsoleDeveloperId", "InitialReleaseDate", "Name" },
                values: new object[] { new Guid("24040a96-0264-4911-b9e1-1a47375d913a"), 1, new DateTime(1996, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "64" });

            migrationBuilder.InsertData(
                table: "GamePort",
                columns: new[] { "GamePortId", "GameConsoleId", "GameId", "IsInitialRelease", "IsSameName", "PortName", "ReleaseDate" },
                values: new object[] { new Guid("4a8a9505-c744-4dcb-a822-e43fe04c273b"), new Guid("24040a96-0264-4911-b9e1-1a47375d913a"), new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), true, true, null, null });

            migrationBuilder.InsertData(
                table: "GamePort",
                columns: new[] { "GamePortId", "GameConsoleId", "GameId", "IsInitialRelease", "IsSameName", "PortName", "ReleaseDate" },
                values: new object[] { new Guid("f6d9e9f1-b512-42a0-8213-247b1080689e"), new Guid("3e4ed385-0e49-4758-ab38-86dae54eae63"), new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), false, false, "The Legend of Zelda - Majora's Mask 3D", new DateTime(2015, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PortFeature",
                columns: new[] { "PortFeatureId", "Description", "Feature", "FeatureTypeId", "GameId", "GamePortId" },
                values: new object[,]
                {
                    { new Guid("422b4e25-42d3-466a-9f7e-c9fda861e4cc"), "Swimming speed while wearing the Zora mask is automatically fast without needing to use magic", "Fast Zora Swimming", 1, new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), new Guid("4a8a9505-c744-4dcb-a822-e43fe04c273b") },
                    { new Guid("46b805cf-01ad-4ad8-85b1-4958fcd93f33"), "The original release of Majora's Mask capped out at a framerate of 20 FPS. Little hard on the eyes at first", "20 FPS", 3, new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), new Guid("4a8a9505-c744-4dcb-a822-e43fe04c273b") },
                    { new Guid("cb4e8da2-c16b-4d3e-992f-1d75e2805205"), "The 3DS port runs a bit smoother at 30 FPS, which is easier on the eyes", "30 FPS", 1, new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), new Guid("f6d9e9f1-b512-42a0-8213-247b1080689e") },
                    { new Guid("051cbbd5-3dc9-44b8-88a1-30c372d1f975"), "Some purists may complain that this takes away from the original, the Song of Double Time can take you to a specific time of the current day you are on.", "Improved Song of Double Time", 2, new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), new Guid("f6d9e9f1-b512-42a0-8213-247b1080689e") },
                    { new Guid("4a3d4cfb-c5b2-4e27-bfdf-4b9024413907"), "Without using Magic, the Zora swimming speed will seem like you are crawling through the ocean. Fan patches have been made to patch this though", "Slow Zora Swimming", 3, new Guid("50eb6f62-a159-42ee-ab59-589f38daf243"), new Guid("f6d9e9f1-b512-42a0-8213-247b1080689e") }
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
                name: "IX_PortFeature_GameId",
                table: "PortFeature",
                column: "GameId");

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
