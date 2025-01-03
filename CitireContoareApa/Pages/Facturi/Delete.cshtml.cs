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
    public class DeleteModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public DeleteModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.FindAsync(id);
            if (factura != null)
            {
                Factura = factura;
                _context.Factura.Remove(Factura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
