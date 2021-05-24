using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Pages
{
    public class ArtistsModel : PageModel
    {
        private Chinook db;

        public ArtistsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Artist> Artists { get; set; }
        public void OnGetAsync()
        {
            ViewData["Title"] = "Chinook Web Site - Artists";
            Artists = db.Artists;
        }
        [BindProperty]
        public Artist Artist { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(Artist);
                db.SaveChanges();
                return RedirectToPage("/artists");
            }
            return Page();
        }

        public IActionResult DeleteArtist(int ArtistId)
        {
            var artist = db.Artists.Find(ArtistId);

            if (artist == null) return Page();

            db.Artists.Remove(artist); db.SaveChanges(); return RedirectToPage("/artists");
        }
    }
}