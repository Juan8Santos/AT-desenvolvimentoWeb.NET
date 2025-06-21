using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Pacotes
{
    public class CreateModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public CreateModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        public List<SelectListItem> TodasCidades { get; set; } = new();


        [BindProperty]
        public List<int> CidadesSelecionadas { get; set; } = new();

        public IActionResult OnGet()
        {
            Dados();
            return Page();
        }

        [BindProperty]
        public PacotesTuristicos PacotesTuristicos { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Dados();
                return Page();
            }


            _context.PacoteTuristico.Add(PacotesTuristicos);
            await _context.SaveChangesAsync();


            foreach (var cidade in CidadesSelecionadas)
            {
                var destino = new Destino
                {
                    PacoteTuristicoId = PacotesTuristicos.Id,
                    CidadeDestinoId = cidade
                };
                _context.Destinos.Add(destino);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void Dados()
        {
            TodasCidades = _context.CidadeDestinos.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList();
        }
    }
}
