using Abp.UI;
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
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly App_Context _dbcontext;

        private ILogger<BaseRepository<T>> Logger { get; set; }

        protected BaseRepository(ILoggerFactory logger, App_Context dbcontext)
        {
            Logger = logger.CreateLogger<BaseRepository<T>>();
            //dbConn = new DbConnection(cnnconfig.GetConnectionString("CnnDb"), type).Connection;
            _dbcontext = dbcontext;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                _dbcontext.Set<T>().Remove(result);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Task<IEnumerable<T>> ExecuteAsync(string sql)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbcontext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Erro ao retornar os dados : " + ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var result = await _dbcontext.Set<T>().FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Erro ao retornar os dados : " + ex.Message);
            }

        }

        public async Task<bool> InsertAsync(T entity)
        {
            try
            {
                await _dbcontext.Set<T>().AddAsync(entity);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<T> InsertAsyncGetId(T entity)
        {
            try
            {
                await _dbcontext.Set<T>().AddAsync(entity);
                await _dbcontext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }

        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbcontext.Set<T>().Update(entity);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}
