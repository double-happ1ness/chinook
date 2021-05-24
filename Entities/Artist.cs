using System.Collections.Generic;

namespace Project.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}