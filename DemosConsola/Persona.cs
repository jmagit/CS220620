using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemosConsola.Entidades {
    public enum Color { Blanca, Negra, Amarillo }
    public class Persona : IDisposable {
        private static int cont = 0;
        public const byte MAYORIA_DE_EDAD = 18;
        public readonly byte otraMayoria;
        private int id;
        private string nombre = "(anonimo)", apellidos;
        private int edad = 18;
        private DateTime fechaNacimieto;

        public Persona() {
            cont++;
        }

        public Persona(int id, string nombre, string apellidos, byte mayoria) : this() {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Falta el nombre");
            if (string.IsNullOrWhiteSpace(apellidos))
                throw new Exception("Falta el apellidos");
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            otraMayoria = mayoria;

        }
        ~Persona() {
        }

        public static int NumPersonas { get { return cont; } }

        public void ponNombre(string nombre) {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Falta el nombre");
            this.nombre = nombre;
        }
        public string dameNombre() {
            if (nombre.Length > 5)
                return nombre.Substring(0, 5);
            return nombre;
        }

        public void Dispose() {
            if (cont == 0) return;
            cont--;
        }

        public string Nombre {
            get {
                return nombre;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Falta el nombre");
                nombre = value;
            }
        }
        public string NombreCompleto {
            get {
                return Nombre + " " + apellidos;
            }
        }
        public bool EsMayorDeEdad {
            get {
                return edad >= MAYORIA_DE_EDAD;
            }
        }
        public string Sexos { get; private set; } = "H";

        private string sexo;
        public string Sexo { get { return sexo; } set { sexo = value; } }
    }

    public partial class Profesor: Persona {
        public Decimal Salario { get; set; }

        public string QueEres { get { return "Soy un profesor";  } }
    }

    public class Alumno : Persona {
        public Decimal Nota { get; set; } = 0;

        public string QueEres { get { return "Soy un alumno"; } }
    }
}
