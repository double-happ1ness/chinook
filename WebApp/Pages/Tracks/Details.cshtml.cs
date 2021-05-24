using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.Tracks
{
    public class DetailsModel : PageModel
    {
        private readonly Chinook _context;

        public DetailsModel(Chinook context)
        {
            _context = context;
        }

        public Track Track { get; set; }

        #region snippet_OnGetAsync
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.Tracks
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TrackId == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
