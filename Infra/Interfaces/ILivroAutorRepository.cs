using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ILivroAutorRepository
    {
        Task<bool> AddDadosLivroAutor(int codLivro, int codAutor);
        Task<IEnumerable<LivroAutor>> GetAutorByIdLivro(int codLivro);
    }
}
