using System;

namespace DefinitiveEdition.Api.Data.Models
{
    public class GamePort
    {
        public Guid Id { get; set; }
        public bool IsInitialRelease { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool IsSameName { get; set; }
        public string? PortName { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid GameConsoleId { get; set; }
        public GameConsole GameConsole { get; set; }
    }
}
