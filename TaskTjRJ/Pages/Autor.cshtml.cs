using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskTjRJ.Pages
{
    public class Autor : PageModel
    {
        private readonly ILogger<Autor> _logger;

        public Autor(ILogger<Autor> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
