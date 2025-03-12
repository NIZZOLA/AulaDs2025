using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Models
{
    public class ProdutosModel
    {
        [Key]
        public int Codigo { get; set; }
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [MaxLength(2, ErrorMessage = "O tamanho máximo é de 2 caracteres")]
        public string Unidade { get; set; }
        public decimal Custo { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public decimal Estoque { get; set; }
    }
}
