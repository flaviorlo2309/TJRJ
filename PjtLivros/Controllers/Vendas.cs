using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PjtLivros.Models;
using RestSharp;


namespace PjtLivros.Controllers
{
   
    public class Vendas : Controller
    {
        private IConfiguration _configuration;

        public Vendas(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Index(int? codigo)
        {
            Generic _generic=new Generic();

            var responseApi =  _generic.AcessApi(null, _configuration["ExternalService:Api:Url"],"Livro/GetAllLivrosInfo", "GET");

            var registros = JsonConvert.DeserializeObject<IEnumerable<Domain.Entity.Livro>>(responseApi.Result);
           
            ViewBag.Livros=registros;

         
            var tpvenda = _generic.AcessApi(null, _configuration["ExternalService:Api:Url"], "TipoVenda/GetTpVenda", "GET");
            var rTpVenda = JsonConvert.DeserializeObject<List<TpVenda>>(tpvenda.Result);

            ViewBag.tpvenda = rTpVenda;


            if (codigo != null) 
            {
                var LvTipo = _generic.AcessApi(null, _configuration["ExternalService:Api:Url"], "TipoVendaLivro/GetLivroTpVendaById?id=" + codigo, "GET");
                var TpVendaLv = JsonConvert.DeserializeObject<List<LivroTpVenda>>(LvTipo.Result);

                var item = TpVendaLv.Select(x => {

                    return new LivroTpVendaDto
                    {
                        Codl = x.Codl,
                        TpId = x.TpId,
                        Titulo = x.Livro.Titulo,
                        TpVendaDesc = x.TpVenda.Descricao,
                        Valor = x.Valor,
                    };
                });


                ViewBag.tpvendaLivro = item;
            }
            //else
            //{
            //    var item = new LivroTpVendaDto()
            //    {
            //        Codl = 0,
            //        TpId = 0,
            //        Titulo=null,
            //        TpVendaDesc = null,
            //        Valor = 0,

            //    };

            //    ViewBag.tpvendaLivro = item;
            //};

            return View();
        }

        [HttpPost]
        public async Task<bool> AddDadosLivroTpVenda(string dados)
        {

            try
            {
                await AllJsonResults($"TipoVendaLivro/AddTpVendaLivro", Method.Post, dados);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> AllJsonResults(string urlMethod, Method method, string dados)
        {

            var Url = _configuration["ExternalService:Api:Url"].ToString() + urlMethod;
            var client = new RestClient(Url);
            var request = new RestRequest();
            request.Method = method;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "text/plain");          
            var bodyResult = JsonConvert.DeserializeObject<LivroTpVendaDto>(dados);
            request.AddParameter("application/json", bodyResult, ParameterType.RequestBody);


            var response = client.Execute(request);

            return response.Content;
        }

    }
}
