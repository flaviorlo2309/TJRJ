using Abp.Domain.Entities;
using Domain.Dto;
using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class AssuntoRepository : BaseRepository<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
        }

        public async Task<bool> AddDadosAssunto(string dados)
        {
            try
            {
                var result = new Assunto()
                {
                    Descricao = dados
                };

                await InsertAsync(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> AddDadosAssuntoGetId(string dados)
        {
            try
            {
                var result = new Assunto()
                {
                    Descricao = dados
                };

               var retId=  await InsertAsyncGetId(result);
                return retId.CodAs;
            }
            catch (Exception ex)
            {
                throw new Exception($" Could not be saved");
            }
        }


        public Task<bool> DeleteAssuntoId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Assunto>> GetAllAssuntos()
        {
            throw new NotImplementedException();
        }

        public Task<Assunto> GetAssuntoById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Assunto> GetAssuntoByName(string nome)
        {
            try
            {               
                var result =  GetAllAsync().Result.Where(x => x.Descricao == nome).First();                
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> GetAssuntoByNameGetId(string nome)
        {
            try
            {
                var result = GetAllAsync().Result.Where(x => x.Descricao == nome).First();
                return result.CodAs;
            }
            catch (Exception ex)
            {
                throw new Exception($" Could not be saved");
            }
        }

        public async Task<int> InsertAssuntoGetId(string dados)
        {
            try
            {
                var item = new Assunto()
                {
                    Descricao=dados,
                };
                var result= await InsertAsyncGetId(item);
                return result.CodAs;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Task<bool> InsertAssuntoGetId(Assunto dados)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpDateAssunto(Assunto dados)
        {
            throw new NotImplementedException();
        }
               
    }
}
