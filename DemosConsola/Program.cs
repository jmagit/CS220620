using DemosConsola.Entidades;
using MiBiblioteca;
using MiBiblioteca.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemosConsola {
#if DEBUG
    public class Program {
#else
    class Program {
#endif

        static void Main(string[] args) {
            List<Persona> list = new List<Persona>();
            OperacionBinaria op;

            var c = new Calculadora();
            Func<int, int, int> op2 = c.Suma;
            Func<int, int> unaria = c.CambiaSigno;
            Func<string, string, bool> op3;
            Action<int, int, int> pro;

            //op = c.Suma;
            //// ...
            //Console.WriteLine(op(2, 2));
            //op = c.Resta;
            //Console.WriteLine(op(2, 2));
            Calcula(c.Suma);
            Calcula(c.Resta);
            op = delegate (int i, int j) { return i * j; };
            op = (i, j) => i * j;
            op = (i, j) => {
                // ...
                return i* j;
            };
            Console.WriteLine(op(3, 2));

            //Calcula(delegate (int i, int j) { return i * j; });
            //Calcula(c.QueHago('+'));
            //Calcula(c.CambiaSigno);
            var rslt = list
                .Where(item => item.Nombre.StartsWith("P"))
                .OrderBy(item => item.FechaNacimieto)
                //.Select(item => item.Nombre)
                .Select(delegate(Persona item) { return item.Nombre; })
                .Skip(10).Take(5);

        }

        static void Calcula(OperacionBinaria op) {
            Console.WriteLine(op(2, 2));
        }

            static void Genericos(string[] args) {
            var ele = new Elemento<int, string>();
            var ele2 = new Elemento<string, char>();
            var t1 = ele.GetType();
            var t2 = ele2.GetType();
            // Console.WriteLine($"ele: {ele.GetType().FullName} ele2: {ele2.GetType().FullName}");
            //ele.Key = 3;
            //ele.Valor = "cad";
            //ele2.Key = "d";
            //ele2.Valor = 'k';
            //var lista = new List<Persona>();

            //lista.Add(new Alumno() { Nombre = "Alumno", [0] = "Programación" });
            //lista.Add(new Profesor() { Nombre = "Profe", Sexo = "no binario" });

            //Persona p; // = new Persona();
            //var a = new Alumno() { Nombre = "Alumno", [0] = "Programación" };
            //Console.WriteLine($"{a.dameNombre()} {a.QueEres}");
            //p = new Profesor() { Nombre = "Profe", Sexo = "no binario" };
            //Console.WriteLine($"{p.dameNombre()} {p.QueEres} {(p as Profesor).QueEres}");
            //p.dameNombre();
            //var asignatura = a[0];
            //asignatura = a.Asignaturas[0];
            //asignatura = a[0, "dd"];

            ////var hijo = p + a;

            //// var bebe = a.EsMayor(p); // a > p
            ////if (p.EsValido()) {

            ////}
            //if (p is Profesor) {
            //    var profe = p as Profesor;
            //    profe.DarClase();
            //} else if (p is Alumno alum) {
            //    alum.HacerExamen();
            //} else // if(p is Persona) 
            //    {

            //}
        }
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

        public class Punto {
            private int x, y;
            public Punto(int x, int y) {
                this.x = x;
                this.y = y;
            }

            public int X { get { return x; } }
            public int Y { get { return y; } }
        }

        public class Contenedor : ICloneable {
            private Dummy privado = new() { Valor = 888 };
            private Punto punto = new Punto(10, 20);

            public Punto Punto { get { return punto; } }

            public int DameDummyValor() { return privado.Valor; }
            public void PonDummyValor(int valor) { privado.Valor = valor; }

            public Dummy DameDummy() { return privado.Clone() as Dummy; }
            public Punto DamePunto() { return punto; }

            public object Clone() {
                var rslt = base.MemberwiseClone() as Contenedor;
                rslt.privado = this.privado.Clone() as Dummy;
                return rslt;
            }
        }

        public class Dummy : ICloneable {
            /// <summary>
            /// 
            /// </summary>
            public int Valor { get; set; }
            public String Cadena { get; set; }
            public Dummy() { }

            public Dummy(int valor) { Valor = valor; }
            public override string ToString() {
                return Valor.ToString();
            }

            public object Clone() {
                return base.MemberwiseClone();
            }
        }
        static public void Metodo(Dummy porValor, ref Dummy porReferencia, in Dummy deEntrada, out Dummy deSalida) {
            porValor.Valor = 666;
            porValor = new() { Valor = 888 };
            deEntrada.Valor = 777;
            if (porReferencia.Valor > deEntrada.Valor)
                porReferencia = new() { Valor = 123 };
            deSalida = new() { Valor = 777 };
        }
        static public void Metodo(int obligatorio, int porDefecto = 10, int otroParametro = 3) {
        }
        static public void Metodo(string obligatorio, params int[] resto) {
        }

        static void Referencias(string[] args) {
            Metodo(obligatorio: 4, otroParametro: 4);
            Metodo("", 3, 3, 4, 1);
            var c = new Contenedor();
            Console.WriteLine($"c {c.DameDummyValor()}");
            //c.DameDummy().Valor = 111;
            //Console.WriteLine($"Despues {c.DameDummyValor()}");
            var cc = c.Clone() as Contenedor;

            //Object o;
            //if(c is ICloneable) {
            //    o = (c as ICloneable).Clone();
            //} else {
            //    o = c;
            //}

            Console.WriteLine($"Antes cc {cc.DameDummyValor()}");
            c.PonDummyValor(111);
            Console.WriteLine($"Despues cc {cc.DameDummyValor()}");

            //int porValor = 0, porReferencia = 55, deEntrada = 0, deSalida = 44;
            //Console.WriteLine($"{porValor} {porReferencia} {deEntrada} {deSalida}");
            //Metodo(porValor, ref porReferencia, in deEntrada, out deSalida);
            //Console.WriteLine($"{porValor} {porReferencia} {deEntrada} {deSalida}");
            Dummy porValor = new Dummy(0), porReferencia = new Dummy(55), deEntrada = new Dummy(0), deSalida = new Dummy(44);
            Console.WriteLine($"{porValor} {porReferencia} {deEntrada} {deSalida}");
            Metodo(porValor.Clone() as Dummy, ref porReferencia, in deEntrada, out deSalida);
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

            switch (dia) {
                case DiasDeLaSemana.Lunes:
                    break;
                case DiasDeLaSemana.Domingo:
                    break;
            }

            IRepositorio<Persona, int> dao;
#if DEBUG
            dao = new PersonaMockRepositorio();
#else
            dao = new PersonaRepositorio();
#endif
            try {
                //Console.WriteLine($"Personas: {Persona.NumPersonas}");
                //using var p = new Persona(1, "x", "x", 18);
                //Console.WriteLine(p.dameNombre());
                //p.ponNombre("Pepito");
                ////p.nombre = null;
                ////p.ponNombre(null);
                ////p.Nombre = null;
                //// p.NombreCompleto = "";
                //Console.WriteLine($"Personas: {Persona.NumPersonas}");
                //using var pp = new Persona { Nombre = "Pepe", Sexo = "M" };
                //Console.WriteLine($"Personas: {Persona.NumPersonas}");
                //var x = p.otraMayoria;
                //// Persona.MAYORIA_DE_EDAD
                //// p.Sexos = "N";
                //Console.WriteLine(p.NombreCompleto);
                //Console.WriteLine(p.dameNombre().Length);
                //Console.WriteLine("Tengo una persona");
                //System.GC.Collect();
                //System.GC.WaitForPendingFinalizers();
                //Console.WriteLine($"Fin Personas: {Persona.NumPersonas}");

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
