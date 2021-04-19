using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Project.Models;           //changed from 'Project'
using System.Linq;

namespace WebApp.Pages
{
 public class AlbumsModel : PageModel 
 {
     public string Heading1 { get; set; }

     public IEnumerable<string> Albums { get; set; }

     public void OnGet(){
         Heading1 = "Albums";
        //  Albums = new[] {}
        Chinook db = new Chinook();
        Albums = db.Albums.Select( a => a.AlbumId.ToString() + ". " + a.ArtistId + ". " + a.Title);
     }
 }
}