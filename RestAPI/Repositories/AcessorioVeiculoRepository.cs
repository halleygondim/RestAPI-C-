
using RestAPI.Models;
using RestAPI.Models.Data.DTO;
using System.Collections.Generic;
using RestAPI.Repositories.Generic;


/*CASO QUEIRA MÉTODOS ESPECÍFICOS(FORA DO GENÉRICO), TEMOS QUE CRIAR A INTERFACE DECLARANDO OS MÉTODOS DESEJADOS*/

namespace RestAPI.Repositories
{
    public interface AcessorioVeiculoRepository : IRepository<AcessorioVeiculo>
    {

        List<AcessorioVeiculo> buscaAcessorioPorVeiculo(long veiculo);
    }
}
