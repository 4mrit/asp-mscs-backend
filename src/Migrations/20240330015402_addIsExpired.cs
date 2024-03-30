using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mscs.Migrations
{
    /// <inheritdoc />
    public partial class addIsExpired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_expired",
                table: "Devices",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_expired",
                table: "Devices");
        }
    }
}
