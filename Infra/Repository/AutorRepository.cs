using Abp.Domain.Entities;
using Castle.MicroKernel.Registration;
using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public App_Context  _dbContext;
        public AutorRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
            _dbContext=dbcontext;
        }

        public async Task<bool> AddDadosAutor(string dados)
        {
            try
            {
                var result = new Autor()
                {
                    Nome = dados
                };

                await InsertAsync(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> AddDadosAutoroGetId(string dados)
        {
            try
            {
                var result = new Autor()
                {
                    Nome = dados
                };

                var retId = await InsertAsyncGetId(result);
                return retId.CodAu;
            }
            catch (Exception ex)
            {
                throw new Exception($" Could not be saved");
            }
        }

        public Task<bool> DeleteAutorId(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            try
            {               
                return await GetAllAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
        public Task<Autor> GetAutorById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetAutorByName(string nome)
        {
            try
            {
                var result = GetAllAsync().Result.Where(x => x.Nome == nome).First();
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> GetAutorByNameGetId(string nome)
        {
            try
            {
                var result = GetAllAsync().Result.Where(x => x.Nome == nome).FirstOrDefault();
                return result != null ? result.CodAu : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($" Could not be saved");
            }
        }

        public async Task<int> GetAutorByIdLivro(int Id)
        {
            try
            {
                var result = _dbContext.Set<LivroAutor>().AsNoTracking()
                                                    .Include(x => x.Autor)
                                                    .Include(x => x.Livro)
                                                    .Where(x => x.Livro_Codl == Id)
                                                    .First();

                return result != null ? result.Autor_CodAu : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($" Could not be saved");
            }
        }


        public Task<bool> UpDateAutor(Autor dados)
        {
            throw new NotImplementedException();
        }
    }
}
