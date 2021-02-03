using System.Collections.Generic;
using RestAPI.Models;
using RestAPI.Repositories.Generic;
using RestAPI.Models.Data.Converters;
using RestAPI.Models.Data.DTO;


/*IMPLEMENTANDO A INTERFACE DO SERVIÇO
 AQUI USAMOS OS CONVERTERS CASO QUEIRA USAR DTOS.
 */

namespace RestAPI.Services
{
    public class ProprietarioServiceImpl : ProprietarioService
    {
        private IRepository<Proprietario> _repository;

        public ProprietarioServiceImpl(IRepository<Proprietario> repository)
        {
            _repository = repository;
        }

        public Proprietario salvar(Proprietario proprietario)
        {
            proprietario = _repository.salvar(proprietario);
            return proprietario;
        }

        public Proprietario buscarPorId(long id)
        {
            return (_repository.buscarPorId(id));
        }

        public List<Proprietario> buscarTodos()
        {
            return _repository.buscarTodos();
        }

        public Proprietario alterar(Proprietario proprietario)
        {
            proprietario = _repository.alterar(proprietario);
            return proprietario;
        }

        public void remover(Proprietario proprietario)
        {
             _repository.remover(proprietario);

        }

        public bool Exists(long id)
        {
            return _repository.existir(id);
        }
    }
}