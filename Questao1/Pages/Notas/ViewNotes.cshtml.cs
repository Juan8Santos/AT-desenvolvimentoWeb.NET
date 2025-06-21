using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.Notas
{
    public class ViewNotesModel : PageModel
    {
        [BindProperty]
        [Required]
        public string content { get; set; }
        public string path { get; set; }
        public List<string> files { get; set; }
        public string readContent { get; set; }
        public string selected { get; set; }

        public void OnGet(string file = null)
        {
            readNotes(file);
        }

        public void OnPost()
        {
            writeNotes();
        }

        public void readNotes(string file = null)
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            files = Directory.GetFiles(folder, "*.txt").Select(Path.GetFileName).ToList();

            if (!string.IsNullOrEmpty(file))
            {
                string filePath = Path.Combine(folder, file);

                if (System.IO.File.Exists(filePath))
                {
                    selected = file;
                    readContent = System.IO.File.ReadAllText(filePath);
                }
            }
        }

        public void writeNotes()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Random random = new Random();

            int randomId = random.Next(100, 10000);
            string fileName = $"anotation-id{randomId}.txt";
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string completedPath = Path.Combine(folder, fileName);

            using (StreamWriter streamWriter = new StreamWriter(completedPath))
            {
                streamWriter.WriteLine(content);
            }

            path = $"/files/{fileName}";

            files = Directory.GetFiles(folder, "*.txt").Select(Path.GetFileName).ToList();
        }

    }
}
