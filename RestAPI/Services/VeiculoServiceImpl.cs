using System.Collections.Generic;
using RestAPI.Models;
using RestAPI.Repositories.Generic;
using RestAPI.Models.Data.Converters;
using RestAPI.Models.Data.DTO;

namespace RestAPI.Services
{
    public class VeiculoServiceImpl : VeiculoService
    {
        private IRepository<Veiculo> _veiculos;
        private IRepository<Proprietario> _proprietario;

        private readonly VeiculoConverter _converter;

        public VeiculoServiceImpl(IRepository<Veiculo> veiculo, IRepository<Proprietario> proprietario)
        {
            _veiculos = veiculo;
            _proprietario = proprietario;
            _converter = new VeiculoConverter();
        }

        public VeiculoDTO salvar(VeiculoDTO veiculoDTO)
        {
            var veiculoEntity = _converter.Parse(veiculoDTO);
            var prop = _proprietario.buscarPorId(veiculoDTO.proprietario);
            veiculoEntity.proprietario = prop;
            veiculoEntity = _veiculos.salvar(veiculoEntity);
            return _converter.Parse(veiculoEntity);
        }

        public VeiculoDTO buscarPorId(long id)
        {
            return _converter.Parse(_veiculos.buscarPorId(id));
            
        }

        public List<VeiculoDTO> buscarTodos()
        {
            return _converter.ParseList(_veiculos.buscarTodos());
           // return _veiculos.buscarTodos();
        }

        public VeiculoDTO alterar(VeiculoDTO veiculo)
        {
            var veiculokEntity = _converter.Parse(veiculo);
            veiculokEntity = _veiculos.alterar(veiculokEntity);
            return _converter.Parse(veiculokEntity);
            
        }

        public void remover(VeiculoDTO veiculoDTO)
        {
            var veiculoEntity = _converter.Parse(veiculoDTO);
             _veiculos.remover(veiculoEntity);

        }

        public bool Exists(long id)
        {
            return _veiculos.existir(id);
        }

        
    }
}