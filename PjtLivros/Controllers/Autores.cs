using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PjtLivros.Models;
using RestSharp;

namespace PjtLivros.Controllers
{
    public class Autores : Controller
    {
        private IConfiguration _configuration;

        public Autores(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public IActionResult Index()
        {
            Generic generic = new Generic();
            var responseApi = generic.AcessApi(null, _configuration["ExternalService:Api:Url"], "Autor/GetAllAutores", "GET");

            var dados = JsonConvert.DeserializeObject<IEnumerable<Autor>>(responseApi.Result);


            ViewBag.Autores =dados;

            return View();
        }


        [HttpPost]
        public async Task<bool> GravarDados(string dados)
        {
            try
            {
                var Url = _configuration["ExternalService:Api:Url"].ToString() + $"Autor/AddAutores?dados={dados}";
                var client = new RestClient(Url);
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "text/plain");                
               // request.AddParameter("application/json", dados, ParameterType.RequestBody);


                var response = client.Execute(request);

                return true;

            }
            catch (Exception ex) 
            { 
                return false;
            }
        }
    }
}
