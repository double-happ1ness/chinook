using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class Chinook : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Media_type> Media_types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string CurrentDir = System.Environment.CurrentDirectory;
            string ParentDir = System.IO.Directory.GetParent(CurrentDir).FullName;
            string path = System.IO.Path.Combine(ParentDir, "chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
            .ToTable("albums")
                .HasOne(al => al.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(al => al.ArtistId);

            modelBuilder.Entity<Artist>().ToTable("artists");

            modelBuilder.Entity<Media_type>()
            .ToTable("media_types")
            .HasKey(c => c.MediaTypeId);

            modelBuilder.Entity<Genre>().ToTable("genres");


            modelBuilder.Entity<Track>()
    .ToTable("tracks")
    .HasOne(trk => trk.Album)
    .WithMany(trk => trk.Tracks)
    .HasForeignKey(trk => trk.AlbumId)
     .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Track>()
            .ToTable("tracks")
            .HasOne(trk => trk.Genre)
            .WithMany(trk => trk.Tracks)
            .HasForeignKey(trk => trk.GenreId);

            modelBuilder.Entity<Track>()
            .ToTable("tracks")
            .HasOne(trk => trk.Media_type)
            .WithMany(trk => trk.Tracks)
           .HasForeignKey(mtype => mtype.MediaTypeId);
        }
    }
}