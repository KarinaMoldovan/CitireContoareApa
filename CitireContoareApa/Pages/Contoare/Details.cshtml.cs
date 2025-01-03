using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Contoare
{
    public class DetailsModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public DetailsModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public Contor Contor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contor = await _context.Contor.FirstOrDefaultAsync(m => m.ContorId == id);
            if (contor == null)
            {
                return NotFound();
            }
            else
            {
                Contor = contor;
            }
            return Page();
        }
    }
}
