using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TaskTjRJ.Model
{
    public class Livro
    {
        public int CodI { get; set; }
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

        public Autor Autor { get; set; }

    }
}
