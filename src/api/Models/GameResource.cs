using System;
using DefinitiveEdition.Api.Data.Models;

namespace DefinitiveEdition.Api.Models
{
    public class GameResource
    {
        public string Name { get; set; }
        public DateTime InitialReleaseDate { get; set; }

        public Guid SeriesId { get; set; }
        public Series Series { get; set; }
    }
}
