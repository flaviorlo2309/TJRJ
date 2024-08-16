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
    public class LivroAutorRepository : BaseRepository<LivroAutor>, ILivroAutorRepository
    {
        public LivroAutorRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
        }

        public async Task<bool> AddDadosLivroAutor(int codLivro, int codAutor)
        {
            try
            {
                var result = new LivroAutor()
                {
                   Autor_CodAu = codAutor,
                    Livro_Codl = codLivro
                };

                await InsertAsync(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<LivroAutor>> GetAutorByIdLivro(int codLivro)
        {
            try
            {
              var result =  GetAllAsync().Result.Where(x => x.Livro_Codl == codLivro).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
