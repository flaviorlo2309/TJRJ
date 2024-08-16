using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PjtLivros.Models
{
    [Table("Assunto")]
    public class Assunto
    {
        [Key]
        public int CodAs { get; set; }

        [DisplayName("Assunto Descrição")]
        [Required(ErrorMessage = "Informe o assunto do Livro", AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string Descricao { get; set; }
    }
}
