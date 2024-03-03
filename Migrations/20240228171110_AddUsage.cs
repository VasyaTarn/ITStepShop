using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITStepShop.Migrations
{
    /// <inheritdoc />
    public partial class AddUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsageId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_UsageId",
                table: "Product",
                column: "UsageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Usages_UsageId",
                table: "Product",
                column: "UsageId",
                principalTable: "Usages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Usages_UsageId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Usages");

            migrationBuilder.DropIndex(
                name: "IX_Product_UsageId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UsageId",
                table: "Product");
        }
    }
}
