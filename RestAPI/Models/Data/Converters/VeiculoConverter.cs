using System.Collections.Generic;
using RestAPI.Models.Data.Converters;
using RestAPI.Models;
using System.Linq;
using RestAPI.Models.Data.DTO;

namespace RestAPI.Models.Data.Converters
{
    public class VeiculoConverter : IParser<VeiculoDTO, Veiculo>, IParser<Veiculo, VeiculoDTO>
    {
        public Veiculo Parse(VeiculoDTO origin)
        {
            if (origin == null) return new Veiculo();
            return new Veiculo
            {
                id = origin.id,
                placa = origin.placa
            };
        }

        public VeiculoDTO Parse(Veiculo origin)
        {
            if (origin == null) return new VeiculoDTO();
            return new VeiculoDTO
            {
                id = origin.id,
                placa = origin.placa,
                proprietario = (long)origin.proprietario.id
            };
        }

        public List<Veiculo> ParseList(List<VeiculoDTO> origin)
        {
            if (origin == null) return new List<Veiculo>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<VeiculoDTO> ParseList(List<Veiculo> origin)
        {
            if (origin == null) return new List<VeiculoDTO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
