using RestAPI.Models;
using RestAPI.Models.Data.DTO;
using System.Collections.Generic;
using RestAPI.Services.Generic;

namespace RestAPI.Services
{
    public interface AcessorioVeiculoService : IGenericService<AcessorioVeiculoDTO>
    {
        List<AcessorioVeiculo> buscaAcessorioPorVeiculo(long veiculo);
    }
}
