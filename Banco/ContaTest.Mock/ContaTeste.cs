using Conta;
using NUnit.Framework;

namespace ContaTest.Mock
{
    public class Tests
    {
        private ContaBancaria _conta;

        [SetUp]
        public void Setup()
        {
            _conta = new ContaBancaria("23069551823", 200);
        }

        [Test]
        public void TestSolicitarEmprestimo()
        {
            
        }
    }
}