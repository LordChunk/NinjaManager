using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    ArmourType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ninja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Gold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinjaArmour",
                columns: table => new
                {
                    NinjaId = table.Column<int>(nullable: false),
                    ArmourId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinjaArmour", x => new { x.NinjaId, x.ArmourId });
                    table.ForeignKey(
                        name: "FK_NinjaArmour_Armour_ArmourId",
                        column: x => x.ArmourId,
                        principalTable: "Armour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinjaArmour_Ninja_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NinjaArmour_ArmourId",
                table: "NinjaArmour",
                column: "ArmourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NinjaArmour");

            migrationBuilder.DropTable(
                name: "Armour");

            migrationBuilder.DropTable(
                name: "Ninja");
        }
    }
}
