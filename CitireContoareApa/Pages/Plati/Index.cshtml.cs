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
    public class IndexModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public IndexModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public IList<Plata> Plata { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Plata = await _context.Plata
                .Include(p => p.Factura).ToListAsync();
        }
    }
}
