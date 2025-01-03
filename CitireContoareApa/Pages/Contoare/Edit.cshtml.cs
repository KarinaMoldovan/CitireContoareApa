using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Contoare
{
    public class EditModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public EditModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contor Contor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contor =  await _context.Contor.FirstOrDefaultAsync(m => m.ContorId == id);
            if (contor == null)
            {
                return NotFound();
            }
            Contor = contor;
           ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContorExists(Contor.ContorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContorExists(int id)
        {
            return _context.Contor.Any(e => e.ContorId == id);
        }
    }
}
