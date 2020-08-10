using System;
using System.ComponentModel.DataAnnotations;

namespace DefinitiveEdition.Api.Data.Models
{
    public class Series
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
