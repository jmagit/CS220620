using MiBiblioteca;
using System;


namespace DemosConsola {
#if DEBUG
    public class Program {
#else
    class Program {
#endif
        static void Main(string[] args) {
            char caracter = 'ﯔ';
            caracter = (char)64;
            caracter = '\n';
            int i = 4;
            object r = i; // new Int16(i)
            i = (int)r;
            long l = 444444;
            short ss = (short)l;
            
            int? nulo = 4;
            if (nulo.HasValue)
                i = nulo.Value + 4;
            string s = "c:\\dddd\\ddd\"";
            String cad = @"c:\dddd\ddd";
            string nombre = "Mundo";
            string @string = "dd";
#if DEBUG
            Console.WriteLine("Hola " + nombre + ", que tal" + i + cad);
#else
            Console.WriteLine($"Hola {nombre}, que tal {1+i}");
#endif
            Calculadora calc = new Calculadora();
            calc.Suma(4L, (long)3);

            r = "";
            i = int.Parse("222");
            calc = (r as Calculadora);
        }

    }
}
