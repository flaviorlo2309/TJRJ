using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<IEnumerable<LivroDto>> GetAllLivrosInfo();        
        Task<Livro> GetLivroById(int id);
        Task<bool> UpDateLivro(LivroDto dados);
        Task<bool> AddDadosLivro(LivroDto dados);
        Task<bool> DeleteLivroId(int id);
    }
}
