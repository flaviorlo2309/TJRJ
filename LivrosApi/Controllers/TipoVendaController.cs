using Domain.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Infra.Interfaces;

namespace TpVendaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoVendaController : Controller
    {
        public ITpVendaRepository _tpvenda; 
        public TipoVendaController(ITpVendaRepository tpvenda)
        {
            _tpvenda = tpvenda;
        }

        [HttpPost("AddTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<TpVendaDto>), 504)]
        public async Task<bool> AddTpVenda([FromBody] TpVendaDto dados)
        {
            try
            {
                var result = await _tpvenda.AddTpVenda(dados);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("GetTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 504)]
        public async Task<IEnumerable<TpVenda>> GetAllTpVenda()
        {

            var result = await _tpvenda.GetAllTpVenda();
            return result;
        }


        [HttpGet("GetTpVendaById")]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 504)]
        public async Task<TpVenda> GetTpVendaById(int Id)
        {
            var result = await _tpvenda.GetTpVendaById(Id);
            return result;
        }

        [HttpPut("UpDateTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 504)]
        public async Task<bool> UpDateTpVenda([FromBody] TpVenda dados)
        {
            var item = new TpVenda()
            {    
                Id=dados.Id,
                Descricao=dados.Descricao,
            };

            var result = await _tpvenda.UpDateTpVenda(item);
            return result;
        }

        [HttpDelete("DeleteTpVenda")]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 200)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 204)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 400)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 401)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 403)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 404)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 429)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 500)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 503)]
        [ProducesResponseType(typeof(BaseResponse<TpVenda>), 504)]
        public async Task<bool> DeleteTpVenda(int Id)
        {
            var result = await _tpvenda.DeleteTpVendaId(Id);
            return result;
        }
    }
}
