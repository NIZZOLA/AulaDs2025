using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutosModel",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estoque = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosModel", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosModel");
        }
    }
}
