using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Cidades
{
    public class DeleteModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public DeleteModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadeDestinos.FirstOrDefaultAsync(m => m.Id == id);

            if (cidadedestino == null)
            {
                return NotFound();
            }
            else
            {
                CidadeDestino = cidadedestino;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadeDestinos.FindAsync(id);
            if (cidadedestino != null)
            {
                CidadeDestino = cidadedestino;
                _context.CidadeDestinos.Remove(CidadeDestino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
