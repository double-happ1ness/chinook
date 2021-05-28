using System.Collections.Generic;  //addded

namespace Project.Models
{
    public class Media_type
    {
        public  int MediaTypeId { get; set; }
        public  string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}