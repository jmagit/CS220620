using DemosConsola.Entidades;
using MiBiblioteca;
using MiBiblioteca.Enumeraciones;
using System;


namespace DemosConsola {
#if DEBUG
    public class Program {
#else
    class Program {
#endif
        //public enum DiasDeLaSemana {
        //    Lunes = 1, Martes = 3, Miercoles, Jueves, Viernes, Sabado, Domingo
        //}
        //public enum DiasLaborable {
        //    Lunes = 1, Martes = 3, Miercoles, Jueves, Viernes
        //}
        static public void Metodo(int porValor, ref int porReferencia, in int deEntrada, out int deSalida) {
            porValor = 666;
            if (porReferencia > deEntrada)
                porReferencia = 0;
            deSalida = 99;
            ++deSalida;
        }
        static void Main(string[] args) {
            int porValor = 0, porReferencia = 55, deEntrada = 0, deSalida = 44;
            Console.WriteLine($"{porValor} {porReferencia} {deEntrada} {deSalida}");
            Metodo(porValor, ref porReferencia, in deEntrada, out deSalida);
            Console.WriteLine($"{porValor} {porReferencia} {deEntrada} {deSalida}");
        }
        static void Main4(string[] args) {
            int diaSemana = 0;
            diaSemana = 12;

            DiasDeLaSemana dia = DiasDeLaSemana.Lunes;
            var lab = DiasLaborable.Lunes;
            //if(dia == lab) {

            //}
            Enum.GetValues(typeof(DiasDeLaSemana));
            dia = (DiasDeLaSemana)Enum.Parse(typeof(DiasDeLaSemana), "Lunes");

            switch(dia) {
                case DiasDeLaSemana.Lunes:
                    break;
                case DiasDeLaSemana.Domingo:
                    break;
            }

            IRepositorio dao;
#if DEBUG
            dao = new PersonaMockRepositorio();
#else
            dao = new PersonaRepositorio();
#endif
            try {
                Console.WriteLine($"Personas: {Persona.NumPersonas}");
                using var p = new Persona(1, "x", "x", 18);
                Console.WriteLine(p.dameNombre());
                p.ponNombre("Pepito");
                //p.nombre = null;
                //p.ponNombre(null);
                //p.Nombre = null;
                // p.NombreCompleto = "";
                Console.WriteLine($"Personas: {Persona.NumPersonas}");
                using var pp = new Persona { Nombre = "Pepe", Sexo = "M" };
                Console.WriteLine($"Personas: {Persona.NumPersonas}");
                var x = p.otraMayoria;
                // Persona.MAYORIA_DE_EDAD
                // p.Sexos = "N";
                Console.WriteLine(p.NombreCompleto);
                Console.WriteLine(p.dameNombre().Length);
                Console.WriteLine("Tengo una persona");
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Console.WriteLine($"Fin Personas: {Persona.NumPersonas}");

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
                 Console.WriteLine($"Dispose Personas: {Persona.NumPersonas}");
           
            //ICRUD dao2 = new PersonaDB();
            //IModifica dao3 = new PersonaDB();
            //// ...
            //var lista = dao.DameTodos();
            //var persona = dao.DameUno(1);
            //// ...
            //dao.Modifica(persona);
            //if(dao is IDisposable) {
            //    (dao as IDisposable).Dispose();
            //    dao = null;
            //}

            Calculadora c = new(MiBiblioteca.Enumeraciones.Color.Blanca);
            c.Suma(2, 2);
            

            CalculadoraCientifica cc = new CalculadoraCientifica();
            cc.Suma(2, 2);
            cc.Cuadrado(5);


        }

        static void Main3(string[] args) {
            // Array<int> t;
            int[] t = new int[10];
            int[] tt = (int[])t.Clone();
            t[0] = tt[0];
            t[0] = 4;
            if (tt[0] == 4) {

            }
            tt = new int[] { 1, 2, 3, 4 };
            int[,] matriz = new int[2, 3] { { 1, 2, 3 }, { 4, 0, 0 } };
            matriz[0, 1] = 7;
            //matriz[0] = new int[3];

            int[][] t2t = new int[2][];
            t2t[0] = new int[3];
            t2t[1] = new int[6];
            var aux = t2t[0];
            t2t[0] = t2t[1];
            t2t[1] = aux;
            t2t[0][0] = 4;
            int i = t[t.Length - 1];
            tt = t[2..4];
            if (i > 0) {
                if (i > 0) {
                    i = 0;
                    tt = null;
                }
            } else {

            }


            switch (i) {
                // case 0, 1:
                case 0:
                case 1:
                    // ...
                    i = 0;
                    goto case 2;
                case 2:
                    // ...
                    break;
                default:
                    i = 0;
                    break;

            }
            //while (true) {
            //    // ...
            //    if (i > 0) continue;
            //    // ...

            //    if (tt == null) continue;
            //    {
            //        // ...
            //        if (tt == null) {
            //            // ...
            //        }
            //    } 
            //    //...
            //    if (tt == null) break;
            //    // ..
            //    switch (i) {
            //        // case 0, 1:
            //        case 0:
            //        case 1:
            //            // ...
            //            i = 0;
            //            goto case 2;
            //        case 2:
            //            // ...
            //            break;
            //        default:
            //            i = 0;
            //            goto eti;

            //    }

            //}
            //eti:
            //try {

            //} catch {
            //    // ....
            //    goto eti;
            //}

            //for (int a = 0, b = 0; a < 10 && b < 10; a += 2) {

            //}
            //for (i = 0; ++i < tt.Length || tt[i] < 10;) {

            //}
            //foreach (int x in tt) {

            //}
            //if (i > 0) {
            //    i = 0;
            //    tt = null;
            //} else {

            //}

            using (var calc = new Calculadora()) {
                //
                calc.Suma(4, 4);
                //calc.Dispose();
            }

            // var calc = new Calculadora();
            using var calc2 = new Calculadora();
            using var calc1 = new Calculadora();

            // ...
            //    calc.Dispose();
            //calc = null;
            calc2.Suma(3, 3);
        }

        static void Main2(string[] args) {
        otra:
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

            var rslt = ((double)3 / 0) * 0;
            char genero = 'H';
            cad = $"{((genero == 'H' ? "El" : "La") + "s")} primer{(genero == 'H' ? "" : "a")} ...";
            i = cad == null ? 0 : cad.Length;
            i = (cad ?? "").Length;
            ;
            if (cad != null && cad.ToUpper() != null && cad.ToUpper().Length > 0) {

            }
            if (cad?.ToUpper()?.Length > 0) {

            }
            calc = (r as Calculadora);
            calc = ((Calculadora)r);
            if (r is Calculadora) {
                Calculadora xx = (r as Calculadora);
                i = xx.Suma(2, 2);
                // ...
            }

            if (r is Calculadora x) {
                i = x.Suma(2, 2);
            }
            cad += "x";
            cad = cad + "x";

            var nose = new Calculadora();
            Calculadora calculadora = new();

            //dynamic y = new Calculadora();
            //y.Resta();

            object o;
            const int MAX_LENGHT = 4;

            if (cad.Length > 4) {

            }
            if (cad.Length > MAX_LENGHT) {

            }


        }
    }
}
