using Domain.Dto;
using Domain.Entity;

namespace Infra.Interfaces
{
    public interface ITpVendaRepository : IBaseRepository<TpVenda>
    {
        Task<IEnumerable<TpVenda>> GetAllTpVenda();
        Task<TpVenda> GetTpVendaById(int id);
        Task<bool> UpDateTpVenda(TpVenda dados);
        Task<bool> AddTpVenda(TpVendaDto dados);
        Task<bool> DeleteTpVendaId(int id);
    }
}
