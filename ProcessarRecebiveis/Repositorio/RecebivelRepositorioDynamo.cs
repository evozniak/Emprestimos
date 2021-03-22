using ProcessarRecebiveis.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Repositorio
{
    class RecebivelRepositorioDynamo : IRecebivelRepositorio
    {
        public void BuscarPorCredor(Guid credor)
        {
            throw new NotImplementedException();
        }

        public Recebivel BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Recebivel entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Recebivel entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Recebivel> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
