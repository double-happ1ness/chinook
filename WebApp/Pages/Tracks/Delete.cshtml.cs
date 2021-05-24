#region snippet_All
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project.Pages.Tracks
{
    public class DeleteModel : PageModel
    {
        private readonly Chinook _context;

        public DeleteModel(Chinook context)
        {
            _context = context;
        }

        [BindProperty]
        public Track Track { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false) //changed string -> int
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

            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            try
            {
                _context.Tracks.Remove(track);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Tracks");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("/Tracks/Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
#endregion