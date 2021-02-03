using RestAPI.Models.Data.DTO;
using System.Collections.Generic;

namespace RestAPI.Services.Generic
{

    /*PODE-SE DEFINIR UMA INTERFACE GENÉRICA NO SERVICE TAMBÉM.*/

    public interface IGenericService<T>
    {
        T salvar(T objeto);

        T buscarPorId(long id);

        List<T> buscarTodos();

        T alterar(T objeto);

        void remover(T objeto);
    }
}
