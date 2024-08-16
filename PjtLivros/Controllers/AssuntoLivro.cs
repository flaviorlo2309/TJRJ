using Microsoft.AspNetCore.Mvc;
using PjtLivros.Models;
using RestSharp;

namespace PjtLivros.Controllers
{
    public class AssuntoLivro : Controller
    {
        private IConfiguration _configuration;

        public AssuntoLivro(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> GravarDados(string dados)
        {
            try
            {
                var Url = _configuration["ExternalService:Api:Url"].ToString() + $"Assunto/AddAAssunto?dados={dados}";
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
