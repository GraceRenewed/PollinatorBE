using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PollinatorBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserProfileUid = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Liked = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Sun = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gardens_UserProfiles_UserProfileUid",
                        column: x => x.UserProfileUid,
                        principalTable: "UserProfiles",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserProfileUid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Sun = table.Column<string>(type: "text", nullable: false),
                    Liked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_UserProfiles_UserProfileUid",
                        column: x => x.UserProfileUid,
                        principalTable: "UserProfiles",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "Pollinators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserProfileUid = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Liked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pollinators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pollinators_UserProfiles_UserProfileUid",
                        column: x => x.UserProfileUid,
                        principalTable: "UserProfiles",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "GardenPlants",
                columns: table => new
                {
                    GardenId = table.Column<string>(type: "text", nullable: false),
                    PlantId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    UserProfileUid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlants", x => new { x.GardenId, x.PlantId });
                    table.ForeignKey(
                        name: "FK_GardenPlants_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlants_UserProfiles_UserProfileUid",
                        column: x => x.UserProfileUid,
                        principalTable: "UserProfiles",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "GardenPollinator",
                columns: table => new
                {
                    GardensId = table.Column<string>(type: "text", nullable: false),
                    PollinatorsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPollinator", x => new { x.GardensId, x.PollinatorsId });
                    table.ForeignKey(
                        name: "FK_GardenPollinator_Gardens_GardensId",
                        column: x => x.GardensId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPollinator_Pollinators_PollinatorsId",
                        column: x => x.PollinatorsId,
                        principalTable: "Pollinators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantPollinator",
                columns: table => new
                {
                    PlantsId = table.Column<string>(type: "text", nullable: false),
                    PollinatorsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantPollinator", x => new { x.PlantsId, x.PollinatorsId });
                    table.ForeignKey(
                        name: "FK_PlantPollinator_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantPollinator_Pollinators_PollinatorsId",
                        column: x => x.PollinatorsId,
                        principalTable: "Pollinators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Uid", "Email", "Image", "Region", "UserName" },
                values: new object[,]
                {
                    { "user001", "garden.guru@example.com", "https://example.com/images/user12345.jpg", "Pacific Northwest", "GardenGuru" },
                    { "user002", "greenthumb01@example.com", "https://example.com/images/user001.jpg", "Pacific Northwest", "GreenThumb01" },
                    { "user003", "urban.gardener@example.com", "https://example.com/images/user002.jpg", "Midwest", "UrbanGardener" },
                    { "user004", "naturenerd@example.com", "https://example.com/images/user003.jpg", "Southeast", "NatureNerd" },
                    { "user005", "florafan@example.com", "https://example.com/images/user004.jpg", "Southwest", "FloraFan" }
                });

            migrationBuilder.InsertData(
                table: "Gardens",
                columns: new[] { "Id", "Image", "Liked", "Notes", "Region", "Season", "Sun", "Type", "UserProfileUid" },
                values: new object[,]
                {
                    { "garden001", "https://example.com/images/garden001.jpg", true, "Best spot for tomatoes and basil.", "Pacific Northwest", "Summer", "Full Sun", "Vegetable Garden", "user001" },
                    { "garden002", "https://example.com/images/garden002.jpg", true, "Milkweed thriving. Monarchs spotted daily.", "Midwest", "Summer", "Full Sun", "Pollinator Garden", "user002" },
                    { "garden003", "https://example.com/images/garden003.jpg", false, "Great bee and butterfly activity.", "Southeast", "Spring", "Partial Sun", "Native Flower Bed", "user003" },
                    { "garden004", "https://example.com/images/garden004.jpg", true, "Oregano and black-eyed Susans doing well.", "Southwest", "Spring", "Full Sun", "Mixed Herb and Flower Garden", "user004" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Description", "Liked", "Name", "Picture", "Region", "Season", "Sun", "Type", "UserProfileUid" },
                values: new object[,]
                {
                    { "plant_flp001", "Tubular red and pink blooms that attract bees and hummingbirds.", true, "Bee Balm", "https://example.com/images/beebalm.jpg", "Northeast", "Summer", "Full Sun", "Flower", "user001" },
                    { "plant_flp002", "Essential host plant for monarch butterflies.", true, "Milkweed", "https://example.com/images/milkweed.jpg", "Midwest", "Summer", "Full Sun", "Flower", "user002" },
                    { "plant_flp003", "Purple-petaled flower rich in nectar for bees and butterflies.", true, "Coneflower", "https://example.com/images/coneflower.jpg", "Southeast", "Summer", "Full Sun", "Flower", "user003" },
                    { "plant_flp004", "Yellow-petaled wildflower that supports bees and hoverflies.", false, "Black-eyed Susan", "https://example.com/images/blackeyedsusan.jpg", "Southwest", "Summer", "Full Sun", "Flower", "user004" },
                    { "plant001", "Juicy red fruit great for salads.", true, "Tomato", "https://example.com/images/tomato.jpg", "Pacific Northwest", "Summer", "Full Sun", "Vegetable", "user001" },
                    { "plant002", "Fragrant herb often used in Italian dishes.", false, "Basil", "https://example.com/images/basil.jpg", "Pacific Northwest", "Summer", "Partial Sun", "Herb", "user001" }
                });

            migrationBuilder.InsertData(
                table: "Pollinators",
                columns: new[] { "Id", "Description", "Image", "Liked", "Name", "Region", "Season", "UserProfileUid" },
                values: new object[,]
                {
                    { "poll001", "Essential pollinator for fruits, vegetables, and herbs.", "https://example.com/images/honeybee.jpg", true, "Honey Bee", "Pacific Northwest", "Spring to Fall", "user001" },
                    { "poll002", "Fuzzy, robust bee that pollinates tomatoes and native flowers.", "https://example.com/images/bumblebee.jpg", false, "Bumblebee", "Pacific Northwest", "Spring to Fall", "user001" },
                    { "poll003", "Iconic butterfly species reliant on milkweed for reproduction.", "https://example.com/images/monarch.jpg", true, "Monarch Butterfly", "Midwest", "Summer", "user002" },
                    { "poll004", "Colorful butterfly that loves coneflowers and thistles.", "https://example.com/images/paintedlady.jpg", true, "Painted Lady Butterfly", "Southeast", "Summer", "user003" }
                });

            migrationBuilder.InsertData(
                table: "GardenPlants",
                columns: new[] { "GardenId", "PlantId", "Id", "UserProfileUid" },
                values: new object[,]
                {
                    { "garden001", "plant001", "gp10", "user001" },
                    { "garden001", "plant002", "gp14", "user001" },
                    { "garden002", "plant_flp002", "gp11", "user002" },
                    { "garden003", "plant_flp003", "gp12", "user003" },
                    { "garden004", "plant_flp004", "gp13", "user004" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlants_PlantId",
                table: "GardenPlants",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlants_UserProfileUid",
                table: "GardenPlants",
                column: "UserProfileUid");

            migrationBuilder.CreateIndex(
                name: "IX_GardenPollinator_PollinatorsId",
                table: "GardenPollinator",
                column: "PollinatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserProfileUid",
                table: "Gardens",
                column: "UserProfileUid");

            migrationBuilder.CreateIndex(
                name: "IX_PlantPollinator_PollinatorsId",
                table: "PlantPollinator",
                column: "PollinatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserProfileUid",
                table: "Plants",
                column: "UserProfileUid");

            migrationBuilder.CreateIndex(
                name: "IX_Pollinators_UserProfileUid",
                table: "Pollinators",
                column: "UserProfileUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenPlants");

            migrationBuilder.DropTable(
                name: "GardenPollinator");

            migrationBuilder.DropTable(
                name: "PlantPollinator");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Pollinators");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
