using Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaTest
{
    public static class ContaBancariaTest
    {

        public static void SacarTest()
        {
            //Arrange
            var conta = new ContaBancaria("0001", 100);
            var resultadoEsperado = true;

            //Act
            var resultado = conta.Sacar(50);

            //Assert
            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("Teste Sacar ok");
            }
            else
            {
                Console.WriteLine("Teste Sacar Falhou");
            }
        }

        public static void SacarSemSaldoTest()
        {
            //Arrange
            var conta = new ContaBancaria("0001", 100);
            var resultadoEsperado = false;

            //Ack
            var resultado = conta.Sacar(120);

            //Assert
            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("Teste Sacar sem saldo ok");
            }
            else
            {
                Console.WriteLine("Teste Sacar sem saldo Falhou");
            }
        }
    }
}
