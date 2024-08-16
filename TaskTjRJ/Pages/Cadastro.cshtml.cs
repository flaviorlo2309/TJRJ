using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskTjRJ
{
    public class Cadastro : PageModel
    {
        private readonly ILogger<Cadastro> _logger;

        public Cadastro(ILogger<Cadastro> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string tipo = null;
        }
    }

}
