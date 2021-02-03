using Tapioca.HATEOAS;
using System.Collections.Generic;

namespace RestAPI.Models.Data.DTO
{
    public class AcessorioVeiculoDTO : ISupportsHyperMedia
    {
        public long? id { get; set; }
        public long veiculo { get; set; }
        public long acessorio { get; set; }
       
        //SUPORTE AO HATEOAS, PARA SER RESTFUL
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
