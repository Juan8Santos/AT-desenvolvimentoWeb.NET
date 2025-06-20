using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Paises
{
    public class DetailsModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public DetailsModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        public PaisDestino PaisDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisdestino = await _context.PaisDestino.FirstOrDefaultAsync(m => m.Id == id);
            if (paisdestino == null)
            {
                return NotFound();
            }
            else
            {
                PaisDestino = paisdestino;
            }
            return Page();
        }
    }
}
