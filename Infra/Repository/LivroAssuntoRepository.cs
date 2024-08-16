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
    public class LivroAssuntoRepository : BaseRepository<LivroAssunto>, ILivroAssuntoRepository
    {
        private App_Context _Context;
        public LivroAssuntoRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
            _Context = dbcontext;
        }

        public async Task<bool> AddDadosLivroAssunto(int codLivro, int codAssunto)
        {
            try
            {
                var result = new LivroAssunto()
                {
                    Assunto_CodAs= codAssunto,
                    Livro_Codl= codLivro
                };

                await InsertAsync(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  async Task<LivroAssunto> GetAssuntoByIdLivro(int codLivro)
        {
            try
            {
                // var result = GetAllAsync().Result.Where(x => x.Livro_Codl == codLivro).First();
                var result = _Context.Set<LivroAssunto>().Include(x => x.Assunto).Where(x => x.Livro_Codl == codLivro).First();
                return result;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<bool> UpdateBYIdLivro(LivroAssunto dados)
        {
            try
            {  
              return  UpdateAsync(dados);                 
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
