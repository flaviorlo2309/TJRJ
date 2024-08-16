using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("Livro_Assunto")]
    public class LivroAssunto
    {
        [Key]
        public int Id { get; set; }      
        public int Livro_Codl { get; set; }
        [ForeignKey("Assunto")]
        public int Assunto_CodAs { get; set; }
        public Assunto Assunto { get; set; }
    }
}
