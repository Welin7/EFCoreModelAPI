using EFCoreModelAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreModelAPI.Persistence
{
    public class EFCoreAPIDbContext : DbContext
    {
        public EFCoreAPIDbContext(DbContextOptions<EFCoreAPIDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<VideoStore> VideoStores { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder Biulder) 
        {
            //Used FLUENT API to configuration of data base
            Biulder
                .Entity<VideoStore>()
                .ToTable("VideoStore");
            
            Biulder
                .Entity<VideoStore>()
                .HasKey(v => v.Id);

            Biulder
                .Entity<Movie>()
                .HasKey(m => m.Id);

            Biulder
                .Entity<Director>()
                .HasKey(d => d.Id);


            Biulder
                .Entity<VideoStore>()
                .HasData(new VideoStore(1, "Video Store Click Star"), new VideoStore(2, "Video Store Fast Gift"));

            Biulder
                .Entity<VideoStore>()
                .Property(v => v.NameVideoStore)
                .HasMaxLength(256)
                .HasDefaultValue("Video Store Standard")
                .HasColumnName("NameVideoStore");

            //Relationship from one to N
            Biulder
                .Entity<VideoStore>()
                .HasMany(v => v.Movies)
                .WithOne(m => m.VideoStore)
                .HasForeignKey(v => v.VideoStoreId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relationship from one to one
            Biulder
                .Entity<VideoStore>()
                .HasOne(v => v.Director)
                .WithOne()
                .HasForeignKey<Director>(v => v.MovieStoreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
