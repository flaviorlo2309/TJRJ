using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PjtLivros.Models
{

    public class TpVendaLivro
    {
       
        public int Id { get; set; }
        public int Codl { get; set; }
        public int TpId { get; set; }        
        public decimal Valor { get; set; }
   
    }
}
