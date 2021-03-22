using Moq;
using ProcessarRecebiveis.Controle;
using ProcessarRecebiveis.Log;
using ProcessarRecebiveis.Mensageria;
using ProcessarRecebiveis.Modelo;
using ProcessarRecebiveis.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProcessarRecebiveis.Tests
{
    public class RecebivelControllerTest
    {
        Mock<ILog> _log;
        Mock<IMensagem> _mensagem;
        Mock<IRecebivelRepositorio> _repositorio;

        public RecebivelControllerTest()
        {
            _log = new Mock<ILog>();
            _mensagem = new Mock<IMensagem>();
            _repositorio = new Mock<IRecebivelRepositorio>();
        }

        [Fact]
        public async Task RecepcionarRecebivelValidando()
        {
            //Teste com MOCK simples somente para saber se foi inserido.
            var controle = new RecebivelController(_log.Object, _repositorio.Object, new System.Threading.CancellationToken());
            var recebivel = new Recebivel { CodigoCredor = Guid.NewGuid(),
                                            CodigoEmpresa = Guid.NewGuid(),
                                            DataCredito = DateTime.Parse("01/01/2020"),
                                            DataVenda = DateTime.Parse("01/01/2020"),
                                            Id = Guid.NewGuid(),
                                            Parcela = 1,
                                            ValorParcela = 500
                                          };
            await controle.RecepcionarRecebivel(recebivel);

            _repositorio.Verify(r => r.Inserir(recebivel));
        }


    }
}
