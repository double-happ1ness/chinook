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
        public void OnGetAsync()
        {
            ViewData["Title"] = "Chinook Web Site - Tracks";
            Tracks = db.Tracks.Include(a => a.Album);
        }

        // public void OnPostAsync(int? AlbumId, int? TrackId)
        // {
        //     // Collection.SingleOrDefault(c => c.CollectionId == AlbumId);
        // }
    }
}