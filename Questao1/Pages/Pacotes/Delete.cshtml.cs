using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Pacotes
{
    public class DeleteModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public DeleteModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacotesTuristicos PacotesTuristicos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotesturisticos = await _context.PacoteTuristico.FirstOrDefaultAsync(m => m.Id == id);

            if (pacotesturisticos == null)
            {
                return NotFound();
            }
            else
            {
                PacotesTuristicos = pacotesturisticos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotesturisticos = await _context.PacoteTuristico.FindAsync(id);
            if (pacotesturisticos != null)
            {
                PacotesTuristicos = pacotesturisticos;
                _context.PacoteTuristico.Remove(PacotesTuristicos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
