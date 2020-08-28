using System;

namespace DefinitiveEdition.Api.Data.Models
{
    public class Series
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
