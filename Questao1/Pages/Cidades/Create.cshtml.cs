﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Cidades
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
            carregarDados();
            return Page();
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                carregarDados();
                return Page();
            }

            _context.CidadeDestinos.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void carregarDados()
        {
            ViewData["PaisDestinoId"] = new SelectList(_context.PaisDestino, "Id", "Nome");
        }
    }
}
