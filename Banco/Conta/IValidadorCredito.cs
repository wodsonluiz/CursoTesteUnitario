using System;
using System.Collections.Generic;
using System.Text;

namespace Conta
{
    public interface IValidadorCredito
    {
        bool ValidarCredito(string cpf, decimal valor);
    }
}
