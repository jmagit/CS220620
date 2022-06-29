using MiBiblioteca.Enumeraciones;
using System;
using System.Collections.Generic;

namespace MiBiblioteca {
    public delegate int OperacionBinaria(int a, int b);

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
        public long Suma(string a, string b) { //a
            return Suma(long.Parse(a), long.Parse(b));
        }
        public long Suma(string a) { //a
            return Suma(long.Parse(a), long.Parse(a));
        }
        public int Resta(int a, int b) { //a
            return a - b;
        }
        public int CambiaSigno(int a) {
            return -a;
        }

        public bool EsPrimo(int num) {
            for (int i = 2; i < Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }
        public List<int> GetPrimos(int cuantos) {
            List<int> primos = new List<int>();
            int actual = 1;
            while(primos.Count < cuantos) {
                actual++;
                if(EsPrimo(actual)) {
                    primos.Add(actual);
                }
            }
            return primos;
        }

        //public IEnumerator<int> GetPrimos(int cuantos) {

        //    for (int i = 0; i < cuantos; ++i) {
        //        yield return items[i];
        //    }
        //}

        public OperacionBinaria QueHago(char op) {
            switch(op) {
                case '+':
                    return Suma;
                case '-':
                    return Resta;
                default:
                    throw new Exception("Operación desconocida");
            }
        }
        #endregion
    }

    public class CalculadoraCientifica: Calculadora, ICloneable {
        public CalculadoraCientifica(): base(10) {

        }
        public object Clone() {
            throw new NotImplementedException();
        }

        public double Cuadrado(double valor) {
            return Math.Pow(valor, 2);
        }
    }
}
