namespace Produtos.Models;
public record ProdutosRecord(
    int Codigo,
    string Descricao,
    string Unidade,
    decimal Custo,
    decimal Preco,
    string Imagem,
    decimal Estoque
);