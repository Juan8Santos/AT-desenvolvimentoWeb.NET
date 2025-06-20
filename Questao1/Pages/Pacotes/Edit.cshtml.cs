using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Pacotes
{
    public class EditModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public EditModel(AT.Data.EmpresaViagemContext context)
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

            var pacotesturisticos =  await _context.PacoteTuristico.FirstOrDefaultAsync(m => m.Id == id);
            if (pacotesturisticos == null)
            {
                return NotFound();
            }
            PacotesTuristicos = pacotesturisticos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PacotesTuristicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacotesTuristicosExists(PacotesTuristicos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PacotesTuristicosExists(int id)
        {
            return _context.PacoteTuristico.Any(e => e.Id == id);
        }
    }
}
