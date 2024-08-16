using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PjtLivros.Models
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        public int Codl { get; set; }

        [DisplayName("Titulo")]
        [Required(ErrorMessage = "Informe o título do Livro", AllowEmptyStrings = false)]
        [MaxLength(40)]
        public string Titulo { get; set; }

        [DisplayName("Editora")]
        [Required(ErrorMessage = "Informe a editora do Livro", AllowEmptyStrings = false)]
        [MaxLength(40)]
        public string Editora { get; set; }

        [DisplayName("Edição")]
        [Required(ErrorMessage = "Informe a edição do Livro", AllowEmptyStrings = false)]     
        public int Edicao { get; set; }

        [DisplayName("Ano Publicação")]
        [Required(ErrorMessage = "Informe a editora do Livro", AllowEmptyStrings = false)]
        [MaxLength(4)]
        public string AnoPublicacao {  get; set; }  

        public Autor Autores { get; set; }


        [DisplayName("Assunto")]
        [Required(ErrorMessage = "Informe o assunto do Livro", AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string Assunto { get; set; }

        [DisplayName("Valor")]        
        //[Required(ErrorMessage = "Informe o valor do Livro", AllowEmptyStrings = false)]
        [Required, RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Amount must be a number with two decimal place")]
        public decimal Valor { get; set; }

    }
}
