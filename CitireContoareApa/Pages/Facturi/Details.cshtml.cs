using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Facturi
{
    public class DetailsModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public DetailsModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public Factura Factura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.FirstOrDefaultAsync(m => m.FacturaId == id);
            if (factura == null)
            {
                return NotFound();
            }
            else
            {
                Factura = factura;
            }
            return Page();
        }
    }
}
