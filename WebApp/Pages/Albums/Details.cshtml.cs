using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.Albums
{
    public class DetailsModel : PageModel
    {
        private readonly Chinook _context;

        public DetailsModel(Chinook context)
        {
            _context = context;
        }

        public Album Album { get; set; }

        #region snippet_OnGetAsync
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Albums
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
