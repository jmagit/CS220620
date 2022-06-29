using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBiblioteca {
    public static class ValidarCadenas {

        public static bool EstaVacia(this string cad) {
            return string.IsNullOrWhiteSpace(cad);
        }
        public static bool EstaRellena(this string cad) {
            return !EstaVacia(cad);
        }
        public static bool MaxLenght(this string cad, int len) {
            return cad == null || cad.Length <= len;
        }
        public static bool EnMayusculas(this string cad) {
            return cad == null || cad.ToUpper() == cad;
        }
        public static bool Positivo(this int valor) {
            return valor > 0;
        }
    }
}
