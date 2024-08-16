
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Livro_TpVenda_Valor")]
    public class LivroTpVenda
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Livro")]
        public int Codl { get; set; }
        [ForeignKey("TpVenda")]
        public int TpId {  get; set; }
        public decimal Valor { get; set; }
        public Livro Livro { get; set; }
        public TpVenda TpVenda { get; set; }


    }
}
