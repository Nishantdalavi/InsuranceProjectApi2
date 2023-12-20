using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EInsuranceProject.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchemeId",
                table: "SchemeDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchemeId",
                table: "SchemeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
