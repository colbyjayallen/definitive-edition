using System;

namespace DefinitiveEdition.Api.Data.Models
{
    public class PortFeature
    {
        public Guid PortFeatureId { get; set; }
        public string Feature { get; set; }
        public string Description { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid GamePortId { get; set; }
        public GamePort GamePort { get; set; }

        public int FeatureTypeId { get; set; }
        public FeatureType FeatureType { get; set; }
    }
}
