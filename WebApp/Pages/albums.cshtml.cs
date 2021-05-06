using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;

namespace Project.Pages
{
    public class AlbumsModel : PageModel
    {
        private Chinook db;

        public AlbumsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<string> Albums { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Chinook Web Site - Albums";
            // Albums = db.Albums.Select(s => s.Title);
            Albums = db.Albums.Select(s => s.AlbumId.ToString() + ". " + s.ArtistId + ". " + s.Title);
        }
        [BindProperty]
        public Album Album { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(Album);
                db.SaveChanges();
                return RedirectToPage("/albums");
            }
            return Page();
        }

        // void RemoveAlbum(int albumId)
        // {
        //     var album = db.Albums.Find(albumId);
        //     if (album == null)
        //         throw new ArgumentOutOfRangeException();
        //     db.Albums.Remove(album);
        //     db.SaveChanges();
        // }

        public IActionResult DeleteAlbum(int AlbumId)
        {
            var album = db.Albums.Find(AlbumId);

            if (album == null) return Page();

            db.Albums.Remove(album); db.SaveChanges(); return RedirectToPage("/albums");
        }
    }
}