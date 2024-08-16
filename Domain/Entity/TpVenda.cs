using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("tpVenda")]
    public class TpVenda
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }        
    }
}
