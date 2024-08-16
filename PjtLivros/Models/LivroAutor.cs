using System.ComponentModel.DataAnnotations.Schema;

namespace PjtLivros.Models
{
    [Table("LivroAutor")]
    public class LivroAutor
    {
        public int Livro_CodI {  get; set; }
        public int Autor_CodAu { get; set; }
    }
}
