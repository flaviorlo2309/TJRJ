using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class LivroTpVendaDto
    {
        public int Id { get; set; }
        public int Codl { get; set; }       
        public int TpId { get; set; }
        public decimal Valor { get; set; }
        public string Titulo { get; set; }
        public string TpVendaDesc { get; set; }

    }
}
