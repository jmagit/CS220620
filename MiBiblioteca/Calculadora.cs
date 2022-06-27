using MiBiblioteca.Enumeraciones;
using System;

namespace MiBiblioteca {
    public class Calculadora: IDisposable {
        readonly int max;

        public Calculadora() {

        }
        public Calculadora(Color color) {

        }

        public Calculadora(int max = 0) {
            this.max = max;
        }

        public void Dispose() {
            // throw new NotImplementedException();
        }

        #region Atributos
        #endregion
        #region Métodos
        /// <summary>
        /// Método que suma dos valores
        /// </summary>
        /// <param name="a">Primer operando</param>
        /// <param name="b">Segundo operando</param>
        /// <returns>suma del primer operando con el segundo operando </returns>
        public int Suma(int a, int b) { //a
            return a + b;
        }
        public long Suma(long a, long b) { //b
            return a + b;
        }
        #endregion
    }

    public class CalculadoraCientifica: Calculadora, ICloneable {
        public object Clone() {
            throw new NotImplementedException();
        }

        public double Cuadrado(double valor) {
            return Math.Pow(valor, 2);
        }
    }
}
