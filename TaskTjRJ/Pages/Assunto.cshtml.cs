using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskTjRJ.Pages
{
    public class Assunto : PageModel
    {
        private readonly ILogger<Assunto> _logger;

        public Assunto(ILogger<Assunto> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
