using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Project.Pages.Artists
{
    public class EditModel : PageModel
    {
        private readonly Chinook _context;

        public EditModel(Chinook context)
        {
            _context = context;
        }

        [BindProperty]
        public Artist Artist { get; set; }
        public string ErrorMessage { get; set; }

        #region snippet_OnGetPost
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
        {
            Artist = await _context.Artists
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtistId == id);

            if (Artist == null)
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
            var artistToUpdate = await _context.Artists.FindAsync(id);

            if (artistToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Artist>(
                artistToUpdate,
                "artist",
                s => s.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Artists");
            }

            return Page();
        }
        #endregion

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
