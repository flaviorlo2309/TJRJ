using Domain;
using Domain.Dto;
using Domain.Entity;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livro;
        public LivroController(ILivroRepository livro)
        {
             _livro = livro;
        }

        [HttpPost("AddLivros")]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 504)]
        public async Task<bool> AddLivros([FromBody] LivroDto dados)
        {
            try
            {
                var result = await _livro.AddDadosLivro(dados);
                return result;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        [HttpGet("GetLivros")]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 200)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 204)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 400)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 401)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 403)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 404)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 429)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 500)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 503)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 504)]
        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            
            var result = await _livro.GetAllLivros();
            return result;
        }

        [HttpGet("GetAllLivrosInfo")]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 504)]
        public async Task<IEnumerable<LivroDto>> GetAllLivrosInfo()
        {
            try
            {
                var result = await _livro.GetAllLivrosInfo();
                return result;
            }
            catch (Exception ex) 
            {
                return null;
            }
            
        }

       

        [HttpGet("GetLivroById")]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 200)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 204)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 400)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 401)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 403)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 404)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 429)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 500)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 503)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 504)]
        public async Task<Livro> GetLivroById(int Id)
        {
            var result = await _livro.GetLivroById(Id);
            return result;
        }

        [HttpPut("UpDateLivro")]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 504)]
        public async Task<bool> UpDateLivro([FromBody] LivroDto dados)
        {
            var result = await _livro.UpDateLivro(dados);
            return result;
        }

        [HttpDelete("DeleteLivro")]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 200)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 204)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 400)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 401)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 403)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 404)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 429)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 500)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 503)]
        [ProducesResponseType(typeof(BaseResponse<Livro>), 504)]
        public async Task<bool> DeleteLivro(int Id)
        {
            var result = await _livro.DeleteLivroId(Id);
            return result;
        }
    }
}
