using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("Livro_Autor")]
    public class LivroAutor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Livro")]
        public int Livro_Codl {  get; set; }
        [ForeignKey("Autor")]
        public int Autor_CodAu { get; set; }
        public Autor Autor { get; set; }
        public Livro Livro { get; set; }
    }
}
