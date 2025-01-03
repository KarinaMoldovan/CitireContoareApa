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
    public class IndexModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public IndexModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public IList<Contor> Contor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Contor = await _context.Contor
                .Include(c => c.User).ToListAsync();
        }
    }
}
