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
    public class IndexModel : PageModel
    {
        private readonly VolsWebApp.Data.VolContext _context;

        public IndexModel(VolsWebApp.Data.VolContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vols != null)
            {
                Vol = await _context.Vols.ToListAsync();
            }
        }
    }
}
