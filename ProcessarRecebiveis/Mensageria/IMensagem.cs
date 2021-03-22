using ProcessarRecebiveis.Controle;
using ProcessarRecebiveis.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Mensageria
{
    public interface IMensagem
    {
        /// <summary>
        /// Receber as 
        /// </summary>
        /// <param name="tokenCancelamento">Esse método fica aguardando as mensagens, usar o token de cancelamento para quebrar o laço.</param>
        /// <returns></returns>
        public Task ReceberMensagensAsync(CancellationToken tokenCancelamento, RecebivelController controle);
    }
}
