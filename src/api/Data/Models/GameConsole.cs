using System;

namespace DefinitiveEdition.Api.Data.Models
{
    public class GameConsole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime InitialReleaseDate { get; set; }

        public int ConsoleDeveloperId { get; set; }
        public ConsoleDeveloper ConsoleDeveloper { get; set; }
    }
}
