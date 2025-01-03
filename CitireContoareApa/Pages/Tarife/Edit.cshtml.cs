﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitireContoareApa.Data;
using CitireContoareApa.Models;

namespace CitireContoareApa.Pages.Tarife
{
    public class EditModel : PageModel
    {
        private readonly CitireContoareApa.Data.CitireContoareApaContext _context;

        public EditModel(CitireContoareApa.Data.CitireContoareApaContext context)
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

            var tarif =  await _context.Tarif.FirstOrDefaultAsync(m => m.TarifId == id);
            if (tarif == null)
            {
                return NotFound();
            }
            Tarif = tarif;
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

            _context.Attach(Tarif).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarifExists(Tarif.TarifId))
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

        private bool TarifExists(int id)
        {
            return _context.Tarif.Any(e => e.TarifId == id);
        }
    }
}