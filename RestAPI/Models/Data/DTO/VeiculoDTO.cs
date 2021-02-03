using Tapioca.HATEOAS;
using System.Collections.Generic;

namespace RestAPI.Models.Data.DTO
{
    public class VeiculoDTO : ISupportsHyperMedia
    {
        public long? id { get; set; }
        public string placa { get; set; }
        public long proprietario { get; set; }
       
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
