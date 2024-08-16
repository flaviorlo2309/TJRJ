using Domain;
using Domain.Dto;
using Domain.Entity;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace VendasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : Controller
    {
        private ITpVendaLivroRepository _Vendas;
        public VendasController(ITpVendaLivroRepository vendas)
        {
            _Vendas = vendas;
        }

        [HttpPost("AddVendas")]
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
        public async Task<bool> AddVendas([FromBody] LivroTpVendaDto dados)
        {
            try
            {
                var result = await _Vendas.AddDadosVendas(dados);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("GetVendas")]
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
        public async Task<IEnumerable<LivroTpVenda>> GetAllVendas()
        {

            var result = await _Vendas.GetAllVendas();
            return result;
        }


        [HttpGet("GetVendasById")]
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
        public async Task<LivroTpVenda> GetVendasById(int Id)
        {
            var result = await _Vendas.GetVendasById(Id);
            return result;
        }

        [HttpPut("UpDateVendas")]
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
        public async Task<bool> UpDateVendas([FromBody] LivroTpVenda dados)
        {
            var result = await _Vendas.UpDateVendas(dados);
            return result;
        }

        [HttpDelete("DeleteVendas")]
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
        public async Task<bool> DeleteVendas(int Id)
        {
            var result = await _Vendas.DeleteVendasId(Id);
            return result;
        }
    }
}

