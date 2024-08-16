using System.ComponentModel.DataAnnotations.Schema;

namespace PjtLivros.Models
{
    [Table("LivroAssunto")]
    public class LivroAssunto
    {
        public int Livro_Cod { get; set; }
        public int Assunto_codAs { get; set; }
    }
}
