using System;
using System.Collections.Generic;
using System.Text;

namespace Conta
{
    public class ValidadorCredito : IValidadorCredito
    {
        private readonly string _cpf; 
        public ValidadorCredito(string cpf)
        {
            _cpf = cpf;
        }

        public bool ValidarCredito(string cpf, decimal valor)
        {
            bool statusSerasa = VerificarSerasa(cpf);
            bool statusSPC = VerificaSPC(cpf);

            return (statusSerasa && statusSPC);
        }

        private bool VerificaSPC(string cpf)
        {
            return true;
        }

        private bool VerificarSerasa(string cpf)
        {
            return true;
        }
    }
}
