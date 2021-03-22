using ProcessarRecebiveis.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Repositorio
{
    public interface IRepositorioBuilder
    {
        public IRecebivelRepositorio BuildRepoRecebivel();
        //Aqui vão os outros repositórios..
    }
}
