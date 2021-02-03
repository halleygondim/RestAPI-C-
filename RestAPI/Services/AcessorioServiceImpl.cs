using System.Collections.Generic;
using RestAPI.Models;
using RestAPI.Models.Data.DTO;
using RestAPI.Repositories.Generic;
using RestAPI.Models.Data.Converters;



namespace RestAPI.Services
{
    public class AcessorioServiceImpl : AcessorioService
    {
        private IRepository<Acessorio> _repository;

        public AcessorioServiceImpl(IRepository<Acessorio> repository)
        {
            _repository = repository;
        }

        public Acessorio salvar(Acessorio acessorio)
        {
            acessorio = _repository.salvar(acessorio);
            return acessorio;
        }

        public Acessorio buscarPorId(long id)
        {
            return (_repository.buscarPorId(id));
        }

        public List<Acessorio> buscarTodos()
        {
            return _repository.buscarTodos();
        }

        public Acessorio alterar(Acessorio acessorio)
        {
            acessorio = _repository.alterar(acessorio);
            return acessorio;
        }

        public void remover(Acessorio acessorio)
        {
             _repository.remover(acessorio);

        }

        public bool Exists(long id)
        {
            return _repository.existir(id);
        }

       
    }
}