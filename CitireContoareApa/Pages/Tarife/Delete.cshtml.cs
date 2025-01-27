﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public DeleteModel(CitireContoareApa.Data.CitireContoareApaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarif Tarif { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarif.FirstOrDefaultAsync(m => m.TarifId == id);

            if (tarif == null)
            {
                return NotFound();
            }
            else
            {
                Tarif = tarif;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarif.FindAsync(id);
            if (tarif != null)
            {
                Tarif = tarif;
                _context.Tarif.Remove(Tarif);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
