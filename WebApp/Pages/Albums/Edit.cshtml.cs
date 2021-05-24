using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Project.Pages.Albums
{
    public class EditModel : PageModel
    {
        private readonly Chinook _context;

        public EditModel(Chinook context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }
        public string ErrorMessage { get; set; }

        #region snippet_OnGetPost
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
        {
            Album = await _context.Albums
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            if (Album == null)
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
            var albumToUpdate = await _context.Albums.FindAsync(id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Album>(
                albumToUpdate,
                "album",
                s => s.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Albums");
            }

            return Page();
        }
        #endregion

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
