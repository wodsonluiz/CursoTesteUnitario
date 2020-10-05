using System;
using System.Threading;

namespace Conta
{
    public class ContaBancaria
    {
        private string _cpf;
        private decimal _saldo;
        private IValidadorCredito _validadorCredito;

        public ContaBancaria(string cpf, decimal saldo)
        {
            _cpf = cpf;
            _saldo = saldo;
        }

        public void SetValidadorCredito(IValidadorCredito validadorCredito)
        {
            _validadorCredito = validadorCredito;
        }

        public decimal GetSaldo()
        {
            return _saldo;
        }

        public void Depositar(decimal valor)
        {
            _saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;
        }

        public bool Sacar2(decimal valor)
        {
            Thread.Sleep(2000);

            if (valor <= 0)
            {
                return false;
            }

            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;
        }

        public bool SolicitarEmprestimo(decimal valor)
        {
            bool resultado = false;

            if (valor >= _saldo * 10)
            {
                return resultado;
            }

            try
            {
                resultado = _validadorCredito.ValidarCredito(this._cpf, valor);
            }
            catch (InvalidOperationException)
            {

                return resultado;
            }

            if (resultado)
            {
                this._saldo += valor;
            }

            return resultado;
        }
    }
}
