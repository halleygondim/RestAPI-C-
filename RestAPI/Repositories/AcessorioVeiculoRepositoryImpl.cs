
using RestAPI.Models;
using RestAPI.Models.Data.DTO;
using RestAPI.Models.Context;
using RestAPI.Repositories.Generic;
using System.Linq;
using System.Collections.Generic;


/*UMA VEZ DEFINIDA A INTEFACE DEVE-SE IMPLEMENTÁ-LA*/

namespace RestAPI.Repositories
{ 

    public class AcessorioVeiculoRepositoryImpl : GenericRepository<AcessorioVeiculo>, AcessorioVeiculoRepository
    {

        public AcessorioVeiculoRepositoryImpl(OracleContext context) : base (context) {}


    
        public List<AcessorioVeiculo> buscaAcessorioPorVeiculo(long _veiculo) {
         return _context.AcessoriosVeiculos.Where(a => a.veiculo.id.Equals(_veiculo)).ToList();
        }

    }
}
