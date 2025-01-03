using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Tarife
{
    public class IndexModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public IndexModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public IList<Tarif> Tarif { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tarif = await _context.Tarif.ToListAsync();
        }
    }
}
