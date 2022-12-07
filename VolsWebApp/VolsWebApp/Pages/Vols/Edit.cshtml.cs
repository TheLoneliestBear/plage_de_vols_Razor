using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolsWebApp.Data;
using VolsWebApp.Models;

namespace VolsWebApp.Pages.Vols
{
    public class EditModel : PageModel
    {
        private readonly VolsWebApp.Data.VolContext _context;

        public EditModel(VolsWebApp.Data.VolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vol Vol { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vols == null)
            {
                return NotFound();
            }

            var vol =  await _context.Vols.FirstOrDefaultAsync(m => m.Id == id);
            if (vol == null)
            {
                return NotFound();
            }
            Vol = vol;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(Vol.Id))
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

        private bool VolExists(int id)
        {
          return _context.Vols.Any(e => e.Id == id);
        }
    }
}
