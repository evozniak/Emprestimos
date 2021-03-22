using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Repositorio
{
    public interface IRepositorio<T>
    {
        IQueryable<T> ListarTodos();
        void Inserir(T entidade);
        void Excluir(T entidade);
        T BuscarPorID(Guid id);
        void Commit();
        
    }
}
