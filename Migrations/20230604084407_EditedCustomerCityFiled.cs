using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miro.Migrations
{
    /// <inheritdoc />
    public partial class EditedCustomerCityFiled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CsutomerCity",
                table: "Order",
                newName: "CustomerCity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerCity",
                table: "Order",
                newName: "CsutomerCity");
        }
    }
}
