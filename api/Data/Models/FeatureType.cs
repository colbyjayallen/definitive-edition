using System.ComponentModel.DataAnnotations;

namespace DefinitiveEdition.Api.Data.Models
{
    public class FeatureType
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
