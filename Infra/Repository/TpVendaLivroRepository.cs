using Domain.Dto;
using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class TpVendaLivroRepository : BaseRepository<LivroTpVenda>, ITpVendaLivroRepository
    {
        private App_Context _Context;
        public TpVendaLivroRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
            _Context = dbcontext;
        }

        public async Task<bool> AddDadosVendas(LivroTpVendaDto dados)
        {
            try
            {
                var item = new LivroTpVenda()
                {
                    Codl = dados.Codl,
                    TpId = dados.TpId,                                      
                    Valor = dados.Valor,                 
                };
                var result = await InsertAsync(item);
                return result;
            }
            catch(Exception ex) 
            { 
                return false;
            }
        }

        public async Task<bool> DeleteVendasId(int id)
        {
            try
            {
                var result = await DeleteAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public async Task<IEnumerable<LivroTpVenda>> GetAllVendas()
        {
            try
            {
                var result = await GetAllAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       

        public async Task<LivroTpVenda> GetVendasById(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<LivroTpVenda>> GetTpVendasByLivroId(int id)
        {
            try
            {
                var result = _Context.Set<LivroTpVenda>().AsNoTracking()
                                                         .Include(x => x.Livro)
                                                         .Include(x => x.TpVenda)
                                                         .Where(x => x.Livro.Codl == id)
                                                         .ToList();
                
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async  Task<bool> UpDateVendas(LivroTpVenda dados)
        {
            try
            {
                var item = new LivroTpVenda()
                {
                    Codl = dados.Codl,
                    TpId = dados.TpId,                
                    Valor = dados.Valor,                  
                };
                var result = await UpdateAsync(item);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
