using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class LivroDto
    {
       
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }

        public int Edicao { get; set; }

        public string AnoPublicacao { get; set; }

        //public List<AutorDto> Autores { get; set; }
        public string Autores { get; set; }

        public string Assunto { get; set; }
        public decimal Valor { get; set; }

    }
}
