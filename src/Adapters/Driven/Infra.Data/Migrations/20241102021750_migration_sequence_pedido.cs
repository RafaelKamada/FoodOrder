using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration_sequence_pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Pagamento_PagamentoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PedidoStatus_PedidoStatusId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Sacola_SacolaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_SacolasProdutos_Produtos_ProdutoId",
                table: "SacolasProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_SacolasProdutos_Sacola_SacolaId",
                table: "SacolasProdutos");

            migrationBuilder.DropIndex(
                name: "IX_SacolasProdutos_ProdutoId",
                table: "SacolasProdutos");

            migrationBuilder.DropIndex(
                name: "IX_SacolasProdutos_SacolaId",
                table: "SacolasProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PagamentoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PedidoStatusId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_SacolaId",
                table: "Pedidos");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateSequence<int>(
                name: "numero_pedido_seq",
                schema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroPedido",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('public.numero_pedido_seq')",
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "numero_pedido_seq",
                schema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroPedido",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('public.numero_pedido_seq')");

            migrationBuilder.CreateIndex(
                name: "IX_SacolasProdutos_ProdutoId",
                table: "SacolasProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_SacolasProdutos_SacolaId",
                table: "SacolasProdutos",
                column: "SacolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PagamentoId",
                table: "Pedidos",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedidoStatusId",
                table: "Pedidos",
                column: "PedidoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SacolaId",
                table: "Pedidos",
                column: "SacolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Pagamento_PagamentoId",
                table: "Pedidos",
                column: "PagamentoId",
                principalTable: "Pagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PedidoStatus_PedidoStatusId",
                table: "Pedidos",
                column: "PedidoStatusId",
                principalTable: "PedidoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Sacola_SacolaId",
                table: "Pedidos",
                column: "SacolaId",
                principalTable: "Sacola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SacolasProdutos_Produtos_ProdutoId",
                table: "SacolasProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SacolasProdutos_Sacola_SacolaId",
                table: "SacolasProdutos",
                column: "SacolaId",
                principalTable: "Sacola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
