using System;
using System.Collections.Generic;
using DefinitiveEdition.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DefinitiveEdition.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Series> Series { get; set; }
        public DbSet<FeatureType> FeatureType { get; set; }
        public DbSet<ConsoleDeveloper> ConsoleDeveloper { get; set; }
        public DbSet<GameConsole> GameConsole { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GamePort> GamePort { get; set; }
        public DbSet<PortFeature> PortFeature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
                All of these variables are declared before so they can reference
                each other.
            */
            var zeldaSeries = new Series
            {                    
                SeriesId = Guid.NewGuid(),
                Name = "The Legend of Zelda",
                InitialReleaseDate = new DateTime(1986, 2, 21),
                Description = "Save the Princess and Hyrule from Ganon sometimes. Fix me up later...."
            };

            var featureTypes = new List<FeatureType>()
            {
                new FeatureType {FeatureTypeId = 1, Name = "Pro"},
                new FeatureType {FeatureTypeId = 2, Name = "Neutral"},
                new FeatureType {FeatureTypeId = 3, Name = "Con"}
            };

            var nintendo = new ConsoleDeveloper
            {
                ConsoleDeveloperId = 1,
                Name = "Nintendo"
            };

            var n64 = new GameConsole
            {
                GameConsoleId = Guid.NewGuid(),
                Name = "64",
                InitialReleaseDate = new DateTime(1996, 6, 23),
                ConsoleDeveloperId = nintendo.ConsoleDeveloperId
            };

            var n3ds = new GameConsole
            {
                GameConsoleId = Guid.NewGuid(),
                Name = "3DS",
                InitialReleaseDate = new DateTime(2011, 2, 26),
                ConsoleDeveloperId = nintendo.ConsoleDeveloperId
            };

            var majorasMaskGame = new Game
            {
                GameId = Guid.NewGuid(),
                Name = "The Legend of Zelda - Majora's Mask",
                InitialReleaseDate = new DateTime (2000, 4, 27),
                SeriesId = zeldaSeries.SeriesId
            };

            var mm3dsGuid = Guid.NewGuid();
            var mmn64Guid = Guid.NewGuid();
            
            var ports = new List<GamePort>()
            {
                new GamePort
                {
                    GamePortId = mmn64Guid,
                    IsSameName = true,
                    IsInitialRelease = true,
                    GameId = majorasMaskGame.GameId,
                    GameConsoleId = n64.GameConsoleId
                },
                new GamePort
                {
                    GamePortId = mm3dsGuid,
                    IsSameName = false,
                    PortName = "The Legend of Zelda - Majora's Mask 3D",
                    IsInitialRelease = false,
                    ReleaseDate = new DateTime(2015, 2, 13),
                    GameId = majorasMaskGame.GameId,
                    GameConsoleId = n3ds.GameConsoleId,
                }
            };

            var portFeatures = new List<PortFeature>()
            {
                //N64
                new PortFeature
                {
                    PortFeatureId = Guid.NewGuid(),
                    Feature = "Fast Zora Swimming",
                    Description = "Swimming speed while wearing the Zora mask is automatically fast without needing to use magic",
                    FeatureTypeId = 1,
                    GameId = majorasMaskGame.GameId,
                    GamePortId = mmn64Guid
                },
                new PortFeature
                {
                    PortFeatureId = Guid.NewGuid(),
                    Feature = "20 FPS",
                    Description = "The original release of Majora's Mask capped out at a framerate of 20 FPS. Little hard on the eyes at first",
                    FeatureTypeId = 3,
                    GameId = majorasMaskGame.GameId,
                    GamePortId = mmn64Guid
                },
                //3DS
                new PortFeature
                {
                    PortFeatureId = Guid.NewGuid(),
                    Feature = "30 FPS",
                    Description = "The 3DS port runs a bit smoother at 30 FPS, which is easier on the eyes",
                    FeatureTypeId = 1,
                    GameId = majorasMaskGame.GameId,
                    GamePortId = mm3dsGuid
                },
                new PortFeature
                {
                    PortFeatureId = Guid.NewGuid(),
                    Feature = "Improved Song of Double Time",
                    Description = "Some purists may complain that this takes away from the original, the Song of Double Time can take you to a specific time of the current day you are on.",
                    FeatureTypeId = 2,
                    GameId = majorasMaskGame.GameId,
                    GamePortId = mm3dsGuid
                },
                new PortFeature
                {
                    PortFeatureId = Guid.NewGuid(),
                    Feature = "Slow Zora Swimming",
                    Description = "Without using Magic, the Zora swimming speed will seem like you are crawling through the ocean. Fan patches have been made to patch this though",
                    FeatureTypeId = 3,
                    GameId = majorasMaskGame.GameId,
                    GamePortId = mm3dsGuid
                }
            };
            
            modelBuilder.Entity<FeatureType>()
                .HasData(featureTypes);

            modelBuilder.Entity<ConsoleDeveloper>()
                .HasData(nintendo);

            modelBuilder.Entity<Series>()
                .HasData(zeldaSeries);
            
            modelBuilder.Entity<GameConsole>()
                .HasData(n64, n3ds);

            modelBuilder.Entity<Game>()
                .HasData(majorasMaskGame);

            modelBuilder.Entity<GamePort>()
                .HasData(ports);

            modelBuilder.Entity<PortFeature>()
                .HasData(portFeatures);
        }
    }
}
