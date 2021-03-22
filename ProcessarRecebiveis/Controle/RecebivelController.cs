using ProcessarRecebiveis.Log;
using ProcessarRecebiveis.Mensageria;
using ProcessarRecebiveis.Modelo;
using ProcessarRecebiveis.Repositorio;
using ProcessarRecebiveis.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Controle
{
    public class RecebivelController
    {
        public ILog Log { get; init; }
        public IRecebivelRepositorio RecebivelRepositorio { get; init; }
        CancellationToken TokenCancelamento { get; init; }

        public RecebivelController(ILog log, IRecebivelRepositorio recebivelRepositorio, CancellationToken tokenCancelamento)
        {
            Log = log;
            RecebivelRepositorio = recebivelRepositorio;
            this.TokenCancelamento = tokenCancelamento;

            IMensagem mensageria = MensageriaBuilder.Create()
                                                    .SetConnectionString("XXXXX")
                                                    .SetNomeHub("recebiveis")
                                                    .SetLog(log)
                                                    .Build();

            //Vai pausar a thread aqui.
            mensageria.ReceberMensagensAsync(tokenCancelamento, this);
        }

        public async Task RecepcionarRecebivel(Recebivel r)
        {
            Log.Debug($@"Recepcionado recebível ID: { r.Id } ValorParcela: { r.ValorParcela }");
            var validador = new RecebivelValidacao();
            var validacao = await validador.ValidateAsync(r);
            if (validacao.IsValid)
            {
                RecebivelRepositorio.Inserir(r);
                RecebivelRepositorio.Commit(); //Implementar melhor o UNITY OF WORK para controle transacional, gravar a posição da fila processada de forma correta.
            }
            else
            {
                foreach (var erro in validacao.Errors)
                {
                    Log.Error($@"Erro na validação, ID: { r.Id } propriedade: {erro.PropertyName} {erro.ErrorMessage} ");
                }
                
            }
        }


    }
}
