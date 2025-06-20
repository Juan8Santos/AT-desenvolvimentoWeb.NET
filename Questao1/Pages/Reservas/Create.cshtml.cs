using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public CreateModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
        ViewData["PacoteTuristicoId"] = new SelectList(_context.PacoteTuristico, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
