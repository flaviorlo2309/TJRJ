using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TaskTjRJ.Model
{
    public class Autor
    {
        public int CodAu { get; set; }

        [DisplayName("Autores")]
        [Required(ErrorMessage = "Informe o nome do Livro", AllowEmptyStrings = false)]
        [MaxLength(40)]
        public string Nome { get; set; }
    }
}
