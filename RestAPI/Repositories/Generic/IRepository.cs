
using System.Collections.Generic;


namespace RestAPI.Repositories.Generic
{

    /*MÉTODOS QUE NOSSAS CLASSES TERÃO QUE IMPLEMENTAR*/

    public interface IRepository<T> where T : class
    {
        T salvar(T item);
        T buscarPorId(long id);
        List<T> buscarTodos();
        T alterar(T item);
        void remover(T item);
        bool existir(long? id);
        List<T> buscarPorPaginacao(string query);
        int contarLinhas(string query);
    }
}
