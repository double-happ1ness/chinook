using Microsoft.EntityFrameworkCore;
using Project.Models;           

namespace Project.Models        
{
    public class Chinook : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        // public DbSet<Artist> Artists { get; set; }
        // public DbSet<Track> Tracks { get; set; }
        // public DbSet<Genre> Genres { get; set; }
        // public DbSet<Media_type> Media_types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            // string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "chinook.db");
            string CurrentDir = System.Environment.CurrentDirectory;
            string ParentDir = System.IO.Directory.GetParent(CurrentDir).FullName;
            string path = System.IO.Path.Combine(ParentDir, "chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }


        //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {   
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<Track>()
        //     .HasOne(mtype => mtype.Media_type)
        //     .WithMany(trk => trk.Tracks)
        //     .HasForeignKey(mtype => mtype.MediaTypeId)
        //     .OnDelete(DeleteBehavior.NoAction);
        // }   
    }
}