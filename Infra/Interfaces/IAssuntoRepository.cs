using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IAssuntoRepository : IBaseRepository<Assunto>
    {
        Task<IEnumerable<Assunto>> GetAllAssuntos();
        Task<Assunto> GetAssuntoById(long id);
        Task<Assunto> GetAssuntoByName(string nome);       
        Task<int> GetAssuntoByNameGetId(string nome);        
        Task<bool> UpDateAssunto(Assunto dados);
        Task<bool> AddDadosAssunto(string dados);
        Task<bool> InsertAssuntoGetId(Assunto dados);
        Task<int> AddDadosAssuntoGetId(string dados);        
        Task<bool> DeleteAssuntoId(long id);
    }
}
