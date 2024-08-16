using Domain.Dto;
using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infra.Repository
{
    public class TpVendaRepository : BaseRepository<TpVenda>, ITpVendaRepository
    {
        public TpVendaRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
        }

        public async Task<bool> AddTpVenda(TpVendaDto dados)
        {
            try
            {
                var item = new TpVenda()
                {                        
                    Descricao = dados.Descricao,
                };

                await InsertAsync(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTpVendaId(int id)
        {
            try
            {               
                await DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TpVenda>> GetAllTpVenda()
        {
            try
            {
                return await GetAllAsync(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TpVenda> GetTpVendaById(int id)
        {
            try
            {
                return await GetByIdAsync(id); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpDateTpVenda(TpVenda dados)
        {
            try
            {
                await UpdateAsync(dados);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
