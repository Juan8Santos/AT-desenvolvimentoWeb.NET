using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.Simulacao
{
    [Authorize]
    public class DescontoModel : PageModel
    {

        public delegate decimal CalculateDelegate(decimal valor);

        [BindProperty]
        public decimal ValorInformado { get; set; }

        [BindProperty]
        public decimal ValorTotal { get; set; }


        [BindProperty]
        public string? Mensagem { get; set; }

        public Action<decimal> Log { get; set; }

        public static List<string> Memory = new List<string>();

        public void OnGet()
        {
            AnexandoLoggers();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            CalculateDelegate calcular = new CalculateDelegate(CalcularDesconto);
            decimal resultado = calcular(ValorInformado);
            Mensagem = $"Desconto aplicado com sucesso: {resultado}";
            AnexandoLoggers();
            Log?.Invoke(resultado);
            return Page();
        }

        public void AnexandoLoggers()
        {
            Log = LogToConsole;
            Log += LogToMemory;
            Log += LogToFile;
        }

        public decimal CalcularDesconto(decimal valor)
        {
            return valor * 0.9m;
        }

        public void LogToFile(decimal valor)
        {
            var pastaProjeto = Path.Combine(Directory.GetCurrentDirectory(), "Pages", "LogDesconto");
            var caminho = Path.Combine(pastaProjeto, "log.txt");
            System.IO.File.AppendAllText(caminho, valor.ToString() + Environment.NewLine);
        }

        public void LogToMemory(decimal valor)
        {
            string valorConvertido = valor.ToString();
            Memory.Add(valorConvertido);
        }

        public void LogToConsole(decimal valor)
        {
            Console.WriteLine($"Valor com Desconto: {valor}");
        }

    }
}
