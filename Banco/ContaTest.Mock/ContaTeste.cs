using Conta;
using Moq;
using NUnit.Framework;
using System;

namespace ContaTest.Mock
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestSolicitarEmprestimo()
        {
            var conta = new ContaBancaria("23069551825", 100);

            //implementa uma classe fake
            var mock = new Mock<IValidadorCredito>();

            //basicamente efetua a chamada do metodo e estabalece o retorno como [true]
            //It.IsAny<string>()                 => assume qualquer valor como parametro
            //It.Is<decimal>(i => i <= 5000))    => posibilidade de colocar uma condição lambda
            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.Is<decimal>(i => i <= 500))).Returns(true);

            //instancia um mock da sua interface
            conta.SetValidadorCredito(mock.Object);

            var resultadoEsperado = 600;
            conta.SolicitarEmprestimo(500);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);


        }

        [Test]
        public void TestSolicitaEmprestimoComException()
        {
            var conta = new ContaBancaria("23069551825", 100);

            var mock = new Mock<IValidadorCredito>();

            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>())).Throws<InvalidOperationException>();

            conta.SetValidadorCredito(mock.Object);
            var resultadoEsperado = 100;
            conta.SolicitarEmprestimo(500);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);
        }

        [Test]
        public void TestSolicitarEmprestimoAcimaLimite()
        {
            var conta = new ContaBancaria("23069551823", 100);

            var mock = new Mock<IValidadorCredito>();
            conta.SetValidadorCredito(mock.Object);

            var resultado = conta.SolicitarEmprestimo(1500);

            mock.Verify(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>()), Times.Never());
        }
    }
}