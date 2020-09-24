using Calculadora;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraTeste
{
    public static class CalculadoraTest
    {
        public static void SomarTest()
        {
            var calculadora = new CalculadoraPrincipal();

            int resultadoEsperado = 350;

            int resultado = calculadora.Somar(100, 250);

            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("Teste Somar OK");
            }
            else
            {
                Console.WriteLine("Teste somar falhou");
            }
        }

        public static void SomarNegativosTest()
        {
            var calculadora = new CalculadoraPrincipal();

            int resultadoEsperado = -100;

            int resultado = calculadora.Somar(-50, -50);

            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("Teste Somar Negativos OK");
            }
            else
            {
                Console.WriteLine("Teste somar Negativos falhou");
            }
        }
    }
}
