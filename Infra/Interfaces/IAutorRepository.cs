using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IAutorRepository : IBaseRepository<Autor>
    {
        Task<IEnumerable<Autor>> GetAllAutores();
        Task<Autor> GetAutorById(long id);
        Task<int> GetAutorByIdLivro(int Id);
        Task<bool> GetAutorByName(string nome);
        Task<int> GetAutorByNameGetId(string nome);
        Task<bool> UpDateAutor(Autor dados);
        Task<bool> AddDadosAutor(string dados);
        Task<int> AddDadosAutoroGetId(string dados);        
        Task<bool> DeleteAutorId(long id);
    }
}
