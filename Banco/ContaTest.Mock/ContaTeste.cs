using Conta;
using Moq;
using NUnit.Framework;

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
            var conta = new ContaBancaria("23069551823", 100);

            //implementa uma classe fake
            var mock = new Mock<IValidadorCredito>();

            //basicamente efetua a chamada do metodo e estabalece o retorno como [true]
            mock.Setup(x => x.ValidarCredito("23069551823", 5000)).Returns(true);

            //instancia um mock da sua interface
            conta.SetValidadorCredito(mock.Object);

            var resultadoEsperado = 5100;
            conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);


        }
    }
}