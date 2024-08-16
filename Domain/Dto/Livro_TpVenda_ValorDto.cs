using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class Livro_TpVenda_ValorDto
    {
        public int Id { get; set; }       
        public int Codl { get; set; }        
        public int TpId { get; set; }    
        public decimal Valor { get; set; }      
    }
}
