using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolsWebApp.Data;
using VolsWebApp.Models;

namespace VolsWebApp.Pages.Vols
{
    public class DetailsModel : PageModel
    {
        private readonly VolsWebApp.Data.VolContext _context;

        public DetailsModel(VolsWebApp.Data.VolContext context)
        {
            _context = context;
        }

      public Vol Vol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vols == null)
            {
                return NotFound();
            }

            var vol = await _context.Vols.FirstOrDefaultAsync(m => m.Id == id);
            if (vol == null)
            {
                return NotFound();
            }
            else 
            {
                Vol = vol;
            }
            return Page();
        }
    }
}
