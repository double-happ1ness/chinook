using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly Chinook _context;

        public DetailsModel(Chinook context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }

        #region snippet_OnGetAsync
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtistId == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
