using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpTempSimpleApp.Migrations
{
    /// <inheritdoc />
    public partial class Added_BookDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppBooks",
                type: "TEXT",
                maxLength: 512,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppBooks");
        }
    }
}
