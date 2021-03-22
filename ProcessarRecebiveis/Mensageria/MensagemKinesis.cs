using ProcessarRecebiveis.Controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Mensageria
{
    class MensagemKinesis : IMensagem
    {
        public async Task ReceberMensagensAsync(CancellationToken tokenCancelamento, RecebivelController controle)
        {
            throw new NotImplementedException();
        }
    }
}
