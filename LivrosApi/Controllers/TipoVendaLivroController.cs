using Domain.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Infra.Interfaces;
using System.Data.SqlTypes;

namespace TpVendaLivroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoVendaLivroController : Controller
    {
        public ITpVendaLivroRepository _tpvendalv; 
        public TipoVendaLivroController(ITpVendaLivroRepository tpvendalv)
        {
            _tpvendalv = tpvendalv;
        }

        [HttpPost("AddTpVendaLivro")]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVendaDto>), 504)]
        public async Task<bool> AddTpVendaLivro([FromBody] LivroTpVendaDto dados)
        {
            try
            {
                var result = await _tpvendalv.AddDadosVendas(dados);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("GetLivroTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 504)]
        public async Task<IEnumerable<LivroTpVenda>> GetAllTpVenda()
        {

            var result = await _tpvendalv.GetAllVendas();
            return result;
        }


        [HttpGet("GetLivroTpVendaById")]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 504)]
        public async Task<IEnumerable<LivroTpVenda>> GetTpVendaById(int Id)
        {
            var result = await _tpvendalv.GetTpVendasByLivroId(Id);
            return result;
        }

        [HttpPut("UpDateTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 504)]
        public async Task<bool> UpDateTpVenda([FromBody] LivroTpVenda dados)
        {
            var item = new LivroTpVenda()
            {    
                Id=dados.Id,
                Codl=dados.Codl,
                TpId=dados.TpId,
                Valor=dados.Valor
            };

            var result = await _tpvendalv.UpDateVendas(item);
            return result;
        }

        [HttpDelete("DeleteTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroTpVenda>), 504)]
        public async Task<bool> DeleteTpVenda(int Id)
        {
            var result = await _tpvendalv.DeleteVendasId(Id);
            return result;
        }
    }
}
