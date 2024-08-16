using Domain.Dto;
using Infra.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PjtLivros.Models;
using RestSharp;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure;


namespace PjtLivros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IConfiguration _configuration;

        private  IAutorRepository _autor;
       // private  ILivroAutorRepository _livroAutor;
        private  IAssuntoRepository _assunto;
       // private  ILivroAssuntoRepository _livroAssunto;

        public HomeController(ILogger<HomeController> logger
            , IConfiguration configuration
           // , IAutorRepository autor
           // , IAssuntoRepository assunto
            //, ILivroAutorRepository livroAutor
            //, ILivroAssuntoRepository livroAssunto
            )
        {
            _logger = logger;
            _configuration = configuration;
           // _autor = autor;
           // _assunto = assunto;
            //_livroAutor = livroAutor;
           // _livroAssunto=livroAssunto;
        }


        public IActionResult Index()
        {
            Generic generic = new Generic();

            //dados Livros
            var responseApi = generic.AcessApi(null, _configuration["ExternalService:Api:Url"], "Livro/GetAllLivrosInfo", "GET");
           
            //var dados = response.Content;
            var registros = JsonConvert.DeserializeObject<List<LivroDto>>(responseApi.Result);

            List<LivroDto> list = new List<LivroDto>();

            foreach(var item in registros)
            {
                var x = new LivroDto()
                {
                    Codl=item.Codl,
                    Titulo=item.Titulo,
                    AnoPublicacao=item.AnoPublicacao,
                    Assunto= item.Assunto,
                    Autores =item.Autores,
                    Edicao=item.Edicao,
                    Editora=item.Editora,
                    Valor=item.Valor,
                };

                list.Add(x);
            }

            //List<Autor> autors = new List<Autor>();
            //ViewBag.Autor = dados;

            return View(list);
        }

      


        [HttpPut]
        public async Task<bool> AlterarDados(string dados)
        {
            await AllJsonResults($"Livro/UpDateLivro", Method.Put, dados,null);

            return true;
        }

        [HttpDelete]
        public async Task<bool> ExcluirLivro(int dados)
        {
            var result = await AllJsonResults($"Autor/GetAutorByIdLivro?id={dados}", Method.Get, null, dados); 

            if(result == null )
            {
                await AllJsonResults($"Livro/DeleteLivro?id={dados}", Method.Delete, null, dados);
                return true;
            }
            else
            {
                return false;
            }
            

           
        }

        [HttpGet]
        public async Task<IActionResult> GerarRelatorio()
        {
            Document doc = new Document(PageSize.A4, -50, -50, 20, 1);
            doc.AddCreationDate();
            string dados = null;
            var caminho = "C://Projetos//.Net//TJRJ//TaskTjRJ//TaskTjRJ//PDF//livros.pdf"; 

            //
            DataTable lnDados = new DataTable();

            PdfWriter pdfw = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            doc.Open();

            PdfPTable tbHeader = new PdfPTable(1);
            tbHeader.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            float[] colsW = {100};
            tbHeader.SetWidths(colsW);

            Phrase nlaudo1 = new Phrase("Relatório de Livros");
            PdfPCell pcell1 = new PdfPCell(nlaudo1);
            pcell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            pcell1.HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader.AddCell(pcell1);
            doc.Add(tbHeader);


            var Url = _configuration["ExternalService:Api:Url"];
            string result = null;
            var client = new RestClient(Url + $"Livro/GetAllLivrosInfo");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-version", "1.0");
            request.AddHeader("accept", "*/*");

            var response = client.Execute(request);
            //  var items = response.Content.Replace("[", "").Replace("]", "");

            var _dados = response.Content;
            var registros = JsonConvert.DeserializeObject<List<LivroDto>>(_dados);

            List<LivroDto> list = new List<LivroDto>();

            PdfPTable tbHeader_3 = new PdfPTable(8);
            tbHeader_3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            float[] cell_4 = { 5,20,10,19,19,10,10,8 };
            tbHeader_3.SetWidths(cell_4);
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Id"))).HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Título"))).HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Ano Pub.")));
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Assunto"))).HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Autores")));
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Edicao"))).HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Editora"))).HorizontalAlignment = Element.ALIGN_CENTER;
            tbHeader_3.AddCell(new PdfPCell(new Phrase("Valor"))).HorizontalAlignment = Element.ALIGN_CENTER;

            tbHeader_3.TotalWidth = doc.PageSize.Width - 20;
            doc.Add(tbHeader_3);


            foreach (var item in registros)
            {

                PdfPTable tbHeader_1 = new PdfPTable(8);
                tbHeader_1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                float[] colsW2 = { 5, 20, 10, 19, 19, 10, 10, 8 };
                tbHeader_1.SetWidths(colsW2);
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Codl.ToString())));         
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Titulo)));
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.AnoPublicacao)));
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Assunto)));
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Autores)));
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Edicao)));
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Editora)));
                tbHeader_1.AddCell(new PdfPCell(new Phrase(item.Valor.ToString())));

                doc.Add(tbHeader_1);
            }
            doc.Close();

           

            return Json(caminho);


        }

        public async Task<string> AllJsonResults(string urlMethod, Method method, string body,int? codigo)
        {

            var Url = _configuration["ExternalService:Api:Url"].ToString() + urlMethod;
            var client = new RestClient(Url);
            var request = new RestRequest();
            request.Method = method;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "text/plain");
            
            if(body != null)
            {
                var bodyResult = JsonConvert.DeserializeObject<LivroDto>(body);
                request.AddParameter("application/json", bodyResult, ParameterType.RequestBody);
            }
           


            var response = client.Execute(request);

            return response.Content;
        }

       

    }
}
