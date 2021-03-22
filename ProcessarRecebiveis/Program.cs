using ProcessarRecebiveis.Controle;
using System;
using System.Threading;

namespace ProcessarRecebiveis
{   
    class Program
    {
        static void Main(string[] args)
        {
            var log = ApplicationFactory.CreateLog();
            try
            {
                //Exemplo simples, sem uso de framework para injeção de dependência.
                log.Information("Serviço ProcessarRecebiveis iniciado.");

                log.Debug("Construindo repositórios para injeção de dependência.");
                var repoBuilder = ApplicationFactory.CreateRepo();
                var recebivel = repoBuilder.BuildRepoRecebivel();
                var cancel = new CancellationToken(); 

                var controle = new RecebivelController(log, repoBuilder.BuildRepoRecebivel(), cancel);
                if (cancel.IsCancellationRequested)
                    throw new Exception("Fim inesperado da aplicação.");
                else
                    log.Information("Aplicação finalizada de forma normal.");

            }
            catch (Exception e)
            {
                log.Fatal($"Erro fatal na aplicação: " + e.Message);
                throw;
            }
        }
    }
}

/* Observações do dev.
 * Demonstração de alguns patterns SOLID (violado em alguns casos para simplicidade), Factory e Builder (Builder violando o SOLID pois não foram feitos os extension methods).
 * Na arquitetura foi considerado o AWS, mas a minha conta da AWS estava com uma pendência desde 2015, não consegui sucesso com o customer service.
 * Utilizei a Azure como alternativa de mensageria.
 * A ingestão do Event hub e Kinesis suportam milhões de mensagens em TEMPO REAL, desconsiderei os limites de consumo por POD do Kubernetes.
 * Uso de mock para repositório e xUnit.
 * Os logs que estão em console precisam ser tratados para serem gravados no DynamoDB ou outro database.
 * Criar uma lambda que processa a fila e grava todas as mensagens em outra instância do DynamoDB.
 */
