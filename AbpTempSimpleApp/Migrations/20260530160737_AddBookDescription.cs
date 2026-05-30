using AbpTempSimpleApp.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpTempSimpleApp.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(AbpTempSimpleAppDbContext))]
    [Migration("20260530160737_AddBookDescription")]
    public partial class AddBookDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppBooks",
                type: "TEXT",
                maxLength: 1024,
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
