using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PjtLivros.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int CodAu { get; set; }

        [DisplayName("Autor Nome")]
        [Required(ErrorMessage = "Informe o nome do Livro", AllowEmptyStrings = false)]
        [MaxLength(40)]
        public string Nome { get; set; }
    }
}
