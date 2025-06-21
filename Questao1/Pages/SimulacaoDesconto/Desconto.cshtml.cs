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


        public void OnGet()
        {

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

            return Page();
        }

        public decimal CalcularDesconto(decimal valor)
        {
            return valor * 0.9m;
        }

    }
}
