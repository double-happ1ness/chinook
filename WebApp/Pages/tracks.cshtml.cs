using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Pages
{
    public class TracksModel : PageModel
    {
        private Chinook db;

        public TracksModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Track> Tracks { get; set; }
        public void OnGetAsync()
        {
            ViewData["Title"] = "Chinook Web Site - Tracks";
            Tracks = db.Tracks.Include(a => a.Album)
            .Include(a => a.Artist);
        }
        [BindProperty]
        public Track Track { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(Track);
                db.SaveChanges();
                return RedirectToPage("/tracks");
            }
            return Page();
        }

        public IActionResult DeleteTrack(int TrackId)
        {
            var track = db.Tracks.Find(TrackId);

            if (track == null) return Page();

            db.Tracks.Remove(track); db.SaveChanges(); return RedirectToPage("/tracks");
        }
    }
}