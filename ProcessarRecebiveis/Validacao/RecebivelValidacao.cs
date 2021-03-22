using FluentValidation;
using ProcessarRecebiveis.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarRecebiveis.Validacao
{
    public class RecebivelValidacao: AbstractValidator<Recebivel>
    {
        //Somente alguns exemplos de validações usando a Lib FluentValidation.
        public RecebivelValidacao()
        {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.CodigoEmpresa).NotNull().NotEmpty();
            RuleFor(r => r.CodigoCredor).NotNull().NotEmpty();
            RuleFor(r => r.DataCredito).NotNull().NotEmpty();
            RuleFor(r => r.DataVenda).NotNull().NotEmpty();
            RuleFor(r => r.Parcela).NotNull().NotEmpty();
            RuleFor(r => r.ValorParcela).NotNull().NotEmpty();
            RuleFor(r => r).Must(CreditoDepoisDaVenda);
        }

        public bool CreditoDepoisDaVenda(Recebivel r)
        {
            return r.DataVenda <= r.DataCredito;
        }
    }
}
