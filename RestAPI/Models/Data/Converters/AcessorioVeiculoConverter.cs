using System.Collections.Generic;
using RestAPI.Models.Data.Converters;
using System.Linq;
using RestAPI.Models.Data.DTO;
using RestAPI.Repositories.Generic;

namespace RestAPI.Models.Data.Converters
{
    /*SERVE PARA CONVERTER NOSSOS MODELS EM DTOS E O CONTRÁRIO*/

    public class AcessorioVeiculoConverter : IParser<AcessorioVeiculoDTO, AcessorioVeiculo>, IParser<AcessorioVeiculo, AcessorioVeiculoDTO>
    {

        private IRepository<Veiculo> _repositoryVeiculo;
        private IRepository<Acessorio> _repositoryAcessorio;

        public AcessorioVeiculoConverter()
        {

        }


        public AcessorioVeiculoConverter(IRepository<Veiculo> repositoryVeiculo, IRepository<Acessorio> repositoryAcessorio)
        {
            _repositoryVeiculo = repositoryVeiculo;
            _repositoryAcessorio = repositoryAcessorio;
        }


        public AcessorioVeiculo Parse(AcessorioVeiculoDTO origin)
        {
            if (origin == null) return new AcessorioVeiculo();
            return new AcessorioVeiculo
            {
                id = origin.id,
                acessorio = _repositoryAcessorio.buscarPorId(origin.acessorio),
                veiculo = _repositoryVeiculo.buscarPorId(origin.veiculo)
            };
        }

        public AcessorioVeiculoDTO Parse(AcessorioVeiculo origin)
        {
            if (origin == null) return new AcessorioVeiculoDTO();
            return new AcessorioVeiculoDTO
            {
                id = origin.id,
                acessorio = (long)origin.acessorio.id,
                veiculo = (long)origin.veiculo.id
            };
        }

        public List<AcessorioVeiculo> ParseList(List<AcessorioVeiculoDTO> origin)
        {
            if (origin == null) return new List<AcessorioVeiculo>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AcessorioVeiculoDTO> ParseList(List<AcessorioVeiculo> origin)
        {
            if (origin == null) return new List<AcessorioVeiculoDTO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
