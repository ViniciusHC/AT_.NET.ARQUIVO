using System.ComponentModel.DataAnnotations;
using EscritaLeituraArquivo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EscritaLeituraArquivo.Pages
{
    public class SaveNoteModel : PageModel
    {
        public class InputModel
        {
            [Required(ErrorMessage = "Digite algum conteúdo para salvar.")]
            public string Content { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string UrlDownload { get; private set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {              
                return Page();
            }

            DateTime date = DateTime.Now;
            var nomeArquivo = $"note-{date:yyyyMMdd-HHmmss}.txt";
            var root = Directory.GetCurrentDirectory();
            var caminho = Path.Combine(root, "wwwroot", "files", nomeArquivo);
            UrlDownload = "/files/" + nomeArquivo;

            using (var writer = new StreamWriter(caminho, true))
            {
                writer.WriteLine("Mensagem gravada dia "+date+":\n " + Input.Content);
                TempData["SuccessMessage"] = "Arquivo gravado com sucesso!";
                return Page();
            }

        }
    }
}
