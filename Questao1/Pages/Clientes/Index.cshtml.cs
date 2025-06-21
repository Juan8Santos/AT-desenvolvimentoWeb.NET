using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT.Data;
using AT.Data.Models;

namespace AT.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly AT.Data.EmpresaViagemContext _context;

        public IndexModel(AT.Data.EmpresaViagemContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Cliente.Where(c => c.Deleted == null).ToListAsync();
        }
    }
}
