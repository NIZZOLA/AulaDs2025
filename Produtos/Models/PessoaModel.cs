using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Produtos.Models
{
    public class PessoaModel
    {
        [Key]
        public int Codigo { get; set; }

        [MaxLength(18,ErrorMessage = "O campo só pode ter até {0} caracteres")]
        public string CPF { get; set; }
        
        [MaxLength(50, ErrorMessage = "O campo só pode ter até {0} caracteres")]
        public string Nome { get; set; }
        
        [MaxLength(80, ErrorMessage = "O campo só pode ter até {0} caracteres")]
        public string Email { get; set; }
        
        [MaxLength(15, ErrorMessage = "O campo só pode ter até {0} caracteres")]
        public string Telefone { get; set; }
        
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        [MaxLength(10, ErrorMessage = "A senha só pode ter até {0} caracteres")]
        public string Senha { get; set; }
    }
}
