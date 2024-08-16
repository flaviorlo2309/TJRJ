using Abp.Extensions;
using Domain;
using Domain.Dto;
using Domain.Entity;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssuntoController : Controller
    {
        private readonly IAssuntoRepository _assuntoRepository;
        public AssuntoController(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository= assuntoRepository;
        }

        [HttpPost("AddAAssunto")]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 504)]
        public async Task<bool> AddAAssunto(string dados)
        {
            var result = await _assuntoRepository.AddDadosAssunto(dados);
            return result;
        }

        [HttpGet("GetAssuntoNome")]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<AssuntoDto>), 504)]
        public async Task<Assunto> GetAssuntoByNome(string nome)
        {
            var result = await _assuntoRepository.GetAssuntoByName(nome);
            return result;
        }
    }
}
