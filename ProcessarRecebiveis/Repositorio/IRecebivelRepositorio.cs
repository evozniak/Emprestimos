using ProcessarRecebiveis.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Repositorio
{    
    public interface IRecebivelRepositorio: IRepositorio<Recebivel>
    {
        //DEIXEI para o recebivel ser extensível, OPEN CLOSED principle.
        void BuscarPorCredor(Guid credor);

    }
}
