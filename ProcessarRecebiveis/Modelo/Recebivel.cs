using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessarRecebiveis.Modelo
{
    /// <summary>
    /// Títulos a serem recebidos pelo cliente da conta correte.
    /// Por simplicidade estou utilizando uma única classe para parcela e título.
    /// </summary>
    public class Recebivel
    {
        /// <summary>
        /// ID do título
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Código da empresa dona da conta corrente.
        /// Estou usando um GUID ao invés de uma classe para efeito de simplicidade.
        /// </summary>
        public Guid CodigoEmpresa { get; init; }
        /// <summary>
        /// Cliente do cliente.
        /// Não estou habituado com essa operação, não sei como o banco nomeia esse indivíduo.
        /// </summary>
        public Guid CodigoCredor { get; init; } 
        /// <summary>
        /// Número da parcela.
        /// </summary>
        public short Parcela { get; set; }
        /// <summary>
        /// Data que a venda foi realizada.
        /// </summary>
        public DateTime DataVenda { get; set; }
        /// <summary>
        /// Data a creditar a venda.
        /// </summary>
        public DateTime DataCredito { get; set; }
        /// <summary>
        /// Valor da operação.
        /// </summary>
        public decimal ValorParcela { get; set; }

        public int Somar(int n1, int n2)
        {
            return n1 + n2;
        }
    }
}
