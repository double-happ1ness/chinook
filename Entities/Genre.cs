using System.Collections.Generic;  //added

namespace Project.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}