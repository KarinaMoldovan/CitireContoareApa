using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Plati
{
    public class DetailsModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public DetailsModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public Plata Plata { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plata = await _context.Plata.FirstOrDefaultAsync(m => m.PlataId == id);
            if (plata == null)
            {
                return NotFound();
            }
            else
            {
                Plata = plata;
            }
            return Page();
        }
    }
}
