using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using ProcessarRecebiveis.Controle;
using ProcessarRecebiveis.Log;
using ProcessarRecebiveis.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Mensageria
{
    public class MensagemEventHub : IMensagem
    {
        public string ConnectionString { get; init; }
        public string NomeHub { get; init; }
        public ILog Log { get; set; }

        public MensagemEventHub(string connectionString, string nomeHub, ILog log)
        {
            this.ConnectionString = connectionString;
            this.NomeHub = nomeHub;
            this.Log = log;
        }

        public async Task ReceberMensagensAsync(CancellationToken tokenCancelamento, RecebivelController controle)
        {
            EventHubConsumerClient clienteHub = new EventHubConsumerClient("$Default", ConnectionString, NomeHub);

            Log.Information("Conectando ao Event Hub para receber as mensagens.");

            string particao = await BuscarParticao(clienteHub);
            //Nessa implementação é necessário o controle de OFFSET.
            //portanto uma solução para gravar a posição da mensagem, checkpoints.
            //As mensagens são apagadas automáticamente após o período programado.
            EventPosition posicao = BuscarPosicao(999); //esse contador é controlado por outros métodos suprimidos, nesse caso iniciando na posição 999 da fila.
            await foreach (var Allevent in clienteHub.ReadEventsFromPartitionAsync(particao, posicao, tokenCancelamento))
            {
                var dadosEvento = Allevent.Data;
                var jsonRecebivel = Encoding.UTF8.GetString(dadosEvento.Body.ToArray());
                var recebivel = JsonSerializer.Deserialize<Recebivel>(jsonRecebivel);

                await controle.RecepcionarRecebivel(recebivel);
            }
        }

        private static EventPosition BuscarPosicao(int posicao)
        {
            return EventPosition.FromSequenceNumber(posicao);
        }

        private static async Task<string> BuscarParticao(EventHubConsumerClient clienteHub)
        {
            var output = (await clienteHub.GetPartitionIdsAsync()).First();
            return output;
        }
    }
}
