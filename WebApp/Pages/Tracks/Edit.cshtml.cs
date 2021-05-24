using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Project.Pages.Tracks
{
    public class EditModel : PageModel
    {
        private readonly Chinook _context;

        public EditModel(Chinook context)
        {
            _context = context;
        }

        [BindProperty]
        public Track Track { get; set; }
        public string ErrorMessage { get; set; }

        #region snippet_OnGetPost
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
        {
            Track = await _context.Tracks
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TrackId == id);

            if (Track == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Edit failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var trackToUpdate = await _context.Tracks.FindAsync(id);

            if (trackToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Track>(
                trackToUpdate,
                "track",
                s => s.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Tracks");
            }

            return Page();
        }
        #endregion

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackId == id);
        }
    }
}
