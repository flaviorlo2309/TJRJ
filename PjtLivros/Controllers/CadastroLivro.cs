using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PjtLivros.Models;
using RestSharp;

namespace PjtLivros.Controllers
{
    public class CadastroLivro : Controller
    {
        private IConfiguration _configuration;

        public CadastroLivro(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public IActionResult Index()
        {
            Generic generic =new Generic();
           
            var autors = generic.AcessApi(null, _configuration["ExternalService:Api:Url"], "Autor/GetAllAutores", "GET");
            var dados = JsonConvert.DeserializeObject<List<Domain.Entity.Autor>>(autors.Result);
            ViewBag.Autor = dados;
          
            return View();
        }

        [HttpPost]
        public async Task<bool> GravarDados( string dados)
        {           
            await AllJsonResults($"Livro/AddLivros", Method.Post, dados);

            return true;
        }

        [HttpGet]
        public async Task<LivroDto> GetDados()
        {
            var items = new LivroDto()
            {
                Titulo = "Teste",
                AnoPublicacao = "2024",
                Edicao = 2,
                Editora ="Teste",
                Assunto = "validação",

            };

           // await AllJsonReulst($"Livro/AddLivros", Method.Post, items);

            return items;
        }

        public async Task<string> AllJsonResults(string urlMethod, Method method, string dados)
        {          
          
            var Url = _configuration["ExternalService:Api:Url"].ToString() + urlMethod;
            var client = new RestClient(Url);
            var request = new RestRequest();
            request.Method = method;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "text/plain");
            var bodyResult = JsonConvert.DeserializeObject<LivroDto>(dados);
            request.AddParameter("application/json", bodyResult, ParameterType.RequestBody);

           
            var response = client.Execute(request);

            return response.Content;
        }
    }
}
