﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Data;
using AT.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace AT.Pages.Cidades
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public IndexModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        public IList<CidadeDestino> CidadeDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CidadeDestino = await _context.CidadeDestinos
                .Include(c => c.PaisDestino).ToListAsync();
        }
    }
}
