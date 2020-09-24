using System;
using System.Threading;

namespace Conta
{
    public class ContaBancaria
    {
        private string _cpf;
        private decimal _saldo;

        public ContaBancaria(string cpf, decimal saldo)
        {
            _cpf = cpf;
            _saldo = saldo;
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
            Thread.Sleep(5000);

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
    }
}
