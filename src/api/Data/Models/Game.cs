using System;

namespace DefinitiveEdition.Api.Data.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public DateTime InitialReleaseDate { get; set; }

        public Guid SeriesId { get; set; }
        public Series Series { get; set; }
    }
}
