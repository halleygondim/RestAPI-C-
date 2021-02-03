using System.Collections.Generic;
using RestAPI.Models;
using RestAPI.Repositories;
using RestAPI.Models.Data.Converters;
using RestAPI.Models.Data.DTO;

namespace RestAPI.Services
{
    public class AcessorioVeiculoServiceImpl : AcessorioVeiculoService

    {
        //SEMPRE USAR A INTERFACE
        private AcessorioVeiculoRepository _repository;

        private AcessorioVeiculoConverter _converter;

        public AcessorioVeiculoServiceImpl(AcessorioVeiculoRepository repository)
        {
            _repository = repository;
            _converter = new AcessorioVeiculoConverter();
        }

        public AcessorioVeiculoDTO salvar(AcessorioVeiculoDTO acessorioDTO)
        {
            var acessorioVeiculoEntity = _converter.Parse(acessorioDTO);
            acessorioVeiculoEntity = _repository.salvar(acessorioVeiculoEntity);
            return _converter.Parse(acessorioVeiculoEntity);
        }

        public AcessorioVeiculoDTO buscarPorId(long id)
        {
            return _converter.Parse(_repository.buscarPorId(id));
        }

        public List<AcessorioVeiculoDTO> buscarTodos()
        {
            return _converter.ParseList(_repository.buscarTodos());
        }

        public AcessorioVeiculoDTO alterar(AcessorioVeiculoDTO acessorioDTO)
        {
            var acessorioEntity = _converter.Parse(acessorioDTO);
            acessorioEntity = _repository.alterar(acessorioEntity);
            return _converter.Parse(acessorioEntity);
            
        }

        public void remover(AcessorioVeiculoDTO acessorioDTO)
        {
            var acessorioEntity = _converter.Parse(acessorioDTO);
            _repository.remover(acessorioEntity);

        }

        public bool Exists(long id)
        {
            return _repository.existir(id);
        }

        public List<AcessorioVeiculo> buscaAcessorioPorVeiculo(long veiculo)
        {
            return _repository.buscaAcessorioPorVeiculo(veiculo);
        }
    }
}