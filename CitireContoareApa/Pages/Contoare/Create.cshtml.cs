using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Contoare
{
    public class CreateModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public CreateModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public Contor Contor { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contor.Add(Contor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
