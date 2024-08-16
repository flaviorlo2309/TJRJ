using System.Net.Http.Headers;
using System.Net;
using Domain.Dto;
using Newtonsoft.Json;
using RestSharp;

namespace PjtLivros
{
    public class Generic
    {
        //private IConfiguration _configuration;
        //public Generic(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public async Task<string> AcessApi(string _body, string baseUrl, string endPoint, string method)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(baseUrl);
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                    HttpResponseMessage responseApi = null;

                    switch (method)
                    {

                        case "GET":
                            responseApi = await cliente.GetAsync(endPoint);
                            break;
                        case "POST":                           
                            responseApi = await cliente.PostAsync(endPoint, null);
                            break;
                        case "DELETE":
                            responseApi = await cliente.DeleteAsync(endPoint);
                            break;
                        case "PUT":
                            responseApi = await cliente.PutAsync(endPoint, null);
                            break;
                    };

                    if (responseApi.IsSuccessStatusCode)
                    {
                        var resultApi = await (responseApi.Content.ReadAsStringAsync());
                        return resultApi;
                    }
                    else if (responseApi.StatusCode == HttpStatusCode.Unauthorized)
                        throw new Exception($"{responseApi.StatusCode}");
                    else
                        throw new Exception($"Content: {responseApi.Content.ReadAsStringAsync().Result}");

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
