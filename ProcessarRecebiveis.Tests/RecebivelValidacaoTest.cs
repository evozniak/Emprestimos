using ProcessarRecebiveis.Modelo;
using ProcessarRecebiveis.Validacao;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProcessarRecebiveis.Tests
{
    public class RecebivelValidacaoTest
    {
        [Fact]
        public async Task ValidacaoFuncionando()
        {
            var r = new Recebivel { Id = Guid.NewGuid() };

            var validador = new RecebivelValidacao();
            var validacao = await validador.ValidateAsync(r);

            Assert.False(validacao.IsValid);
        }

        [Fact]
        public void NaoPermitirCreditoAntesDaVenda()
        {
            var validador = new RecebivelValidacao();
            var r = new Recebivel { DataCredito = DateTime.Parse("01/01/2020"), 
                                    DataVenda = DateTime.Parse("02/01/2020")
                                  };

            Assert.False(validador.CreditoDepoisDaVenda(r));
        }
    }
}
