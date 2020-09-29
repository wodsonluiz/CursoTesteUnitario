using System;
using System.Collections.Generic;
using System.Text;

namespace Conta
{
    public class ValidadorCreditoFake : IValidadorCredito
    {
        public bool ValidarCredito(string cpf, decimal valor)
        {

            return true;
        }
    }
}
