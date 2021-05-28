using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Pages
{
    public class ArtistAlbumsModel : PageModel
    {
        private Chinook db;

        public ArtistAlbumsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Album> Albums { get; set; }
        public void OnGetAsync(int id, int ArtistId)
        {
            ViewData["Title"] = "Chinook Web Site - Albums";
            Albums = db.Albums.Include(a => a.Artist).Where(a => a.ArtistId == id);
            Artist = db.Artists.First(x => x.ArtistId == id).Name;
        }

        [BindProperty]
        public Album Album { get; set; }

        [BindProperty]
public string Artist{ get; set; }

        public IActionResult OnPost(int id)
        {
            Album.ArtistId = id;
            if (ModelState.IsValid)
            {
                db.Albums.Add(Album);
                db.SaveChanges();
                return RedirectToPage("/Albums/ArtistAlbums", new {id = id });
            }
            return Page();
        }

        public IActionResult DeleteAlbum(int AlbumId, int id)
        {
            var track = db.Albums.Find(AlbumId);

            if (track == null) return Page();

            db.Albums.Remove(track);
            db.SaveChanges();
            return RedirectToPage("/Albums/ArtistAlbums", new {id = id });
        }
    }
}