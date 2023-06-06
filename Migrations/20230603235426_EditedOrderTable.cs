using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miro.Migrations
{
    /// <inheritdoc />
    public partial class EditedOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CsutomerCity",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerLastName",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerMobile",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerProvince",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageForProvider",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NewsUpdate",
                table: "Order",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentMethod",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CsutomerCity",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerLastName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerMobile",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerProvince",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "MessageForProvider",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "NewsUpdate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShipmentMethod",
                table: "Order");
        }
    }
}
