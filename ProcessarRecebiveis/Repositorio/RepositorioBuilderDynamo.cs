using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Repositorio
{
    public class RepositorioBuilderDynamo : IRepositorioBuilder
    {

        public IRecebivelRepositorio BuildRepoRecebivel()
        {
            IRecebivelRepositorio output = new RecebivelRepositorioDynamo();
            return output;
        }
    }
}
