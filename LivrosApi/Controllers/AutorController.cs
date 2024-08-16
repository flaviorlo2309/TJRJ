using Domain.Dto;
using Domain;
using Infra.Interfaces;
using Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : Controller
    {
        private readonly IAutorRepository _autor;
        public AutorController(IAutorRepository autor)
        {
            _autor = autor;
        }

        [HttpPost("AddAutores")]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 504)]
        public async Task<bool> AddAutores(string dados)
        {
            var result = await _autor.AddDadosAutor(dados);
            return result;
        }

        [HttpGet("GetAssuntoNome")]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 504)]
        public async Task<bool> GetAssuntoByNome(string nome)
        {
            var result = await _autor.GetAutorByName(nome);
            return result;
        }


        [HttpGet("GetAutorByIdLivro")]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<AutorDto>), 504)]
        public async Task<int> GetAutorByIdLivro(int Id)
        {
            var result = await _autor.GetAutorByIdLivro(Id);
            return result;
        }


        [HttpGet("GetAllAutores")]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 200)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 204)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 400)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 401)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 403)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 404)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 429)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 500)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 503)]
        [ProducesResponseType(typeof(BaseResponse<Autor>), 504)]
        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            var result = await _autor.GetAllAutores();
            return result;
        }
    }
}
