using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrder.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration_id_webhook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MercadoPagoId",
                table: "Pagamento",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MercadoPagoId",
                table: "Pagamento");
        }
    }
}
