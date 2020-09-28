using Conta;
using NUnit.Framework;
using System;

namespace ContaTest.NUnit
{
    [TestFixture]
    public class ContaTeste
    {
        private ContaBancaria _conta;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _conta = new ContaBancaria("23069551823", 200);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //código executado apos cada teste unitário
            _conta = null;
        }

        [Test]
        [Category("Principal")]
        [TestCase(120, true)]
        [TestCase(-120, false)]
        public void TesteSacar(int valor, bool result)
        {
            var resultado = _conta.Sacar2(valor);

            Assert.IsTrue(resultado == result);
        }

        [Test]
        [Timeout(6000)]
        public void TesteMetodoLento()
        {
            var resultado = _conta.Sacar2(0);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Valores Invalidos")]
        public void TestSacarSemSaldo()
        {
            var resultado = _conta.Sacar(300);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Valores Invalidos")]
        public void TesteSacarValorNegativo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _conta.Sacar(-100); }); //só vai aceitar exceção declarada no Throws.
            //Assert.Catch<ArgumentOutOfRangeException>(delegate { _conta.Sacar(-100); });  //aceita uma classe de exceção acima na hierarquia.
        }

        [Test]
        [Category("Valores Invalidos")]
        [TestCase(-100)]
        [TestCase(-10)]
        [TestCase(-333)]
        [TestCase(-444)]
        public void TesteSacarValorNegativo2(int valor)
        {
            var resultado = _conta.Sacar2(valor);

            Assert.IsFalse(resultado);
        }
        

        [Test]
        [Category("Principal")]
        [Ignore("Pendencia")]
         public void TestAssert()
        {
            var s = "W";
            var a = 100;
            var b = 4;
            var conta1 = new ContaBancaria("23069551823", 200);
            var conta2 = conta1;

            //Assert.Greater(a, b);                     compara se primeiro parametro é maior que o segundo
            //Assert.AreSame(conta1, conta2);           compara objetos se são os mesmos
            //Assert.IsNull(conta2);                    valida se o objeto é null
            //Assert.Less(a, 200);                      compara se o segundo parametro é maior que o primeiro
            //Assert.Ignore();                          igonora o teste
        }
    }
}