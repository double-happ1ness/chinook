using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Pages
{
    public class AlbumsModel : PageModel
    {
        private Chinook db;

        public AlbumsModel(Chinook injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<Album> Albums { get; set; }
        public void OnGetAsync()
        {
            ViewData["Title"] = "Chinook Web Site - Albums";
            Albums = db.Albums.Include(a => a.Artist);
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

        public IActionResult DeleteAlbum(int AlbumId)
        {
            var album = db.Albums.Find(AlbumId);

            if (album == null) return Page();

            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToPage("/albums");
        }
    }
}