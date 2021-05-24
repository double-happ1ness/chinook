#region snippet_All
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project.Pages.Artists
{
    public class DeleteModel : PageModel
    {
        private readonly Chinook _context;

        public DeleteModel(Chinook context)
        {
            _context = context;
        }

        [BindProperty]
        public Artist Artist { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false) //changed string -> int
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
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            try
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Artists");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("/Artists/Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
#endregion