using System;
using Xunit;
using CalculadoraNewTalents;

namespace TestCalculadoraNewTalent
{
    public class UnitTest1
    {
        public Calculadora construirClasse() 
        {
            string data = "06/11/2024";
            Calculadora _calc = new Calculadora("06/11/2024");
            return _calc;
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(5,4,9)]
        public void TesteSomar(int val1,int val2, int resultado)
        {
            Calculadora _calc = construirClasse();
            int resultadoCalculadora = _calc.somar(val1, val2);
            Assert.Equal(resultado, resultadoCalculadora); ;
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(5, 4, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora _calc = construirClasse();

            int resultadoCalculadora = _calc.multiplicar(val1, val2);
            Assert.Equal(resultado, resultadoCalculadora); ;
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora _calc = construirClasse();

            int resultadoCalculadora = _calc.dividir(val1, val2);
            Assert.Equal(resultado, resultadoCalculadora); ;
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int val1, int val2, int resultado)
        {
            Calculadora _calc = construirClasse();

            int resultadoCalculadora = _calc.subtrair(val1, val2);
            Assert.Equal(resultado, resultadoCalculadora); ;
        }

        [Fact]
        public void TestarDivisaoPorZero() 
        {
            Calculadora _calc = construirClasse();

            Assert.Throws<DivideByZeroException>(
                () => _calc.dividir(3, 0)

             );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora _calc = construirClasse();

            _calc.somar(1, 2);
            _calc.somar(2, 8);
            _calc.somar(3, 7);
            _calc.somar(4, 1);

            var lista = _calc.historico();
            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }

    }
}