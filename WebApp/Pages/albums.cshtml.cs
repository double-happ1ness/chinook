using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project.Models;                  //changed from 'Project'


namespace Project.Pages         //changed from Northwind.Pages
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
            Albums = db.Albums.Select(s => s.Title);
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
    }
}