using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskTjRJ.Model
{
    public class Assunto
    {
        public int CodAs { get; set; }

        [DisplayName("Assunto")]
        [Required(ErrorMessage = "Informe o assunto do Livro", AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string Descricao { get; set; }
    }
}
