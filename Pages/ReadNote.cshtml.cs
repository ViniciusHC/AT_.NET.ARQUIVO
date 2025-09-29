using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EscritaLeituraArquivo.Pages
{
    public class ReadNoteModel : PageModel
    {

        public List<String> ListaArquivos {  get; set; }

        public IActionResult OnGet()
        {
            CarregarLista();
            return Page();

        }

        public void CarregarLista()
        {
                        
            var root = Directory.GetCurrentDirectory();
            var caminho = Path.Combine(root, "wwwroot", "files");
            ListaArquivos = Directory.GetFiles(caminho).Select(Path.GetFileName).ToList();

        }
        
    }
}

