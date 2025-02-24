using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrder.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration_ID_PagamentoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_PagamentoStatus_PagamentoStatusId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_PagamentoStatusId",
                table: "Pagamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_PagamentoStatusId",
                table: "Pagamento",
                column: "PagamentoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_PagamentoStatus_PagamentoStatusId",
                table: "Pagamento",
                column: "PagamentoStatusId",
                principalTable: "PagamentoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
