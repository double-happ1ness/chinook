using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Pages
{
    public class AlbumTracksModel : PageModel
    {
        private Chinook db;

        public AlbumTracksModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Track> Tracks { get; set; }
        public void OnGetAsync(int id)
        {
            ViewData["Title"] = "Chinook Web Site - Tracks";
            Tracks = db.Tracks.Include(a => a.Album).Where(a => a.AlbumId == id);
        }

        [BindProperty]
        public Track Track { get; set; }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(Track);
                db.SaveChanges();
                return RedirectToPage("/Albums/AlbumTracks?id=" + id);
            }
            return Page();
        }

        public IActionResult DeleteTrack(int TrackId, int id)
        {
            var track = db.Tracks.Find(TrackId);

            if (track == null) return Page();

            db.Tracks.Remove(track);
            db.SaveChanges();
            return RedirectToPage("/Albums/AlbumTracks?id=" + id);
        }
    }
}