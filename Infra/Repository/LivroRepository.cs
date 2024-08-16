using Domain.Dto;
using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Infra.Repository
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        private IAssuntoRepository _assunto;
        private IAutorRepository _autor;
        private ILivroAssuntoRepository _livroAssunto;
        private ILivroAutorRepository _livroAutor;
        private readonly App_Context _dbcontext;
       

        public LivroRepository(ILoggerFactory logger, 
            IAssuntoRepository assunto,
            IAutorRepository autor,
            ILivroAssuntoRepository livroAssunto,
            ILivroAutorRepository livroAutor,
            App_Context dbcontext) : base(logger, dbcontext)
        {
            _assunto = assunto;
            _autor = autor;
            _livroAssunto = livroAssunto;
            _livroAutor=livroAutor;
            _dbcontext = dbcontext;
        }

        public async Task<bool> AddDadosLivro( LivroDto dados)
        {
            var autores = "";
            var  idAutor = "";
            int AssuntoCod ;
            int codassunto ;
          

            var tm = dados.Autores.Length;
            
            var retAssunto = await _assunto.GetAssuntoByName(dados.Assunto);

            if(retAssunto == null )
            {
                codassunto = await _assunto.AddDadosAssuntoGetId(dados.Assunto);
                AssuntoCod = codassunto ;
            }
            else
            {
                var retcod = await _assunto.GetAssuntoByNameGetId(dados.Assunto);
                AssuntoCod = retcod ;
            }
                        

            var livro = new Livro
            {
                Titulo = dados.Titulo,
                Editora = dados.Editora,
                Edicao = dados.Edicao,
                AnoPublicacao =dados.AnoPublicacao,
                Valor = dados.Valor
            };

            var result = await InsertAsyncGetId(livro);

            if(result != null)
            {
                
                await _livroAssunto.AddDadosLivroAssunto(result.Codl, AssuntoCod);

                var retAutor = dados.Autores.Substring(0, tm - 1);

                string[] regAut = retAutor.Split(',');

                foreach (var x in regAut)
                {
                    await _livroAutor.AddDadosLivroAutor(result.Codl,int.Parse(x));
                }

            }

            return true;
        }

        public async Task<bool> DeleteLivroId(int id)
        {
            var result = await DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {

            var result = await GetAllAsync();            
        
            return result;
        }

        public async Task<IEnumerable<LivroDto>> GetAllLivrosInfo()
        {
            
            var livro = _dbcontext.Set<Livro>().AsNoTracking().ToList();

            List<LivroDto> list =new List<LivroDto>();

            foreach(var item in livro)
            {
                var _ast = _dbcontext.Set<LivroAssunto>().AsNoTracking()
                                                         .Include(x => x.Assunto) 
                                                         .Where(x => x.Livro_Codl == item.Codl).First();

                var _aut = _dbcontext.Set<LivroAutor>().AsNoTracking()    
                                                        .Include(x => x.Autor)
                                                       .Where(x => x.Livro_Codl == item.Codl);


                string autores = null;

                if (_aut.ToList().Count > 1) 
                {

                    foreach (var reg  in _aut.ToList()) 
                    {
                        autores += reg.Autor.Nome + ",";
                    };
                };

                var x = new LivroDto()
                {
                    Codl = item.Codl,
                    Titulo = item.Titulo,
                    AnoPublicacao = item.AnoPublicacao,
                    Assunto = _ast.Assunto.Descricao,
                    Autores = autores,
                    Edicao = item.Edicao,
                    Editora = item.Editora,
                    Valor = item.Valor,
                };

                list.Add(x);
            }
                                               

            return list;
        }
        public async Task<Livro> GetLivroById(int id)
        {
            var result = await GetByIdAsync(id);
            return result;
        }

        public async Task<bool> UpDateLivro(LivroDto dados)
        {
            var book = new Livro()
            {
                Codl=dados.Codl,
                Titulo=dados.Titulo,
                AnoPublicacao=dados.AnoPublicacao,
                Edicao=dados.Edicao,
                Editora=dados.Editora,
                Valor = dados.Valor  
            };

            var result = await UpdateAsync(book);

            var ast = await _assunto.GetAssuntoByName(dados.Assunto);

            if(ast != null)
            {
                var ast2 = _livroAssunto.GetAssuntoByIdLivro(dados.Codl).Result;
                ast2.Assunto_CodAs= ast.CodAs;
                _livroAssunto.UpdateBYIdLivro(ast2);
            }
            else
            {
               var codAssunto= _assunto.AddDadosAssuntoGetId(dados.Assunto).Result;
                
                await _livroAssunto.AddDadosLivroAssunto(dados.Codl, codAssunto);
            }

            /*           VALIDAÇÃO AUTORES              */

            string[] auts = dados.Autores.Split(',');
            foreach (var aut in auts) 
            {
                var _aut = _autor.GetAutorByName(aut.ToString());
                
                if (_aut.Result == false)
                {
                    var codigo = await _autor.AddDadosAutoroGetId(aut);
                    _livroAutor.AddDadosLivroAutor(dados.Codl, codigo);
                }
                else 
                { 
                    var retAut = _dbcontext.Set<LivroAutor>().AsNoTracking().Include(x => x.Autor).Where(x => x.Autor.Nome== aut).First();

                    if(retAut == null)
                    {                       
                        _livroAutor.AddDadosLivroAutor(dados.Codl, retAut.Autor_CodAu);
                    }
                }
            };
            
            return result;
        }

    }
}
