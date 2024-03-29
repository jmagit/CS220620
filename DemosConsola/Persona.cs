﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemosConsola.Entidades {
    public enum Color { Blanca, Negra, Amarillo }

    public class Direccion {
        public string Calle { get; set; }
    }
    public class EdadChangingEventArg : EventArgs {
        public int NuevaEdad { get; init; }
        public bool Cancel { get; set; } = false;

    }

    public abstract class Persona : IDisposable {
        private static int cont = 0;
        public const byte MAYORIA_DE_EDAD = 18;
        public readonly byte otraMayoria;
        private int id;
        private string nombre = "(anonimo)", apellidos;
        private int edad = 18;
        private DateTime fechaNacimieto;
        private List<Direccion> direcciones;

        public event Action<object, EdadChangingEventArg> EdadChanging;

        protected virtual void OnEdadChanging(EdadChangingEventArg e) {
            if (EdadChanging != null)
                EdadChanging(this, e);
        }

        public Persona() {
            cont++;
        }

        public Persona(int id, string nombre, string apellidos, byte mayoria) : this() {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Falta el nombre");
            if (string.IsNullOrWhiteSpace(apellidos))
                throw new CursoException("Falta el apellidos");
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
        public virtual string dameNombre() {
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
                    throw new CursoException("Falta el nombre");
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

        public abstract bool EsValido();
        public virtual string QueEres { get { return "Soy una persona"; } }

        public int Edad {
            get => edad;
            set {
                if (edad == value) return;
                if (edad < 0)
                    throw new Exception("No puede ser negativa.");
                edad = value;
            }
        }

        public DateTime FechaNacimieto { 
            get => fechaNacimieto; 
            set {
                if (DateTime.Today.CompareTo(value) < 0)
                    throw new CursoException("No acepta fechas futuras");
                var nuevaEdad = DateTime.Today.Year - value.Year - (DateTime.Today.DayOfYear < value.DayOfYear ? 1 : 0);
                var e = new EdadChangingEventArg() { NuevaEdad = nuevaEdad };
                OnEdadChanging(e);
                if (e.Cancel) return;
                fechaNacimieto = value;
                edad = nuevaEdad;
            } 
        }

        public void Guardar() {
            if (VoyAGuardar() && EsValido()) {
                // guarda
                HeGuardado();
            }
        }

        protected virtual bool VoyAGuardar() { return true; }
        protected virtual void HeGuardado() { }

        //public static Persona operator + (Persona p1, Persona p2) {
        //    var bebe = new Persona();
        //    return bebe;
        //}
        // override object.Equals
        public override bool Equals(object obj) {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            return id == (obj as Persona).id;
        }

        // override object.GetHashCode
        public override int GetHashCode() {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }

    }

    public partial class Profesor : Persona {
        public Decimal Salario { get; set; }

        protected override bool VoyAGuardar() {
            return Salario > 1000;
        }
        public void DarClase() { }

        public override bool EsValido() {
            throw new NotImplementedException();
        }
        public override string dameNombre() {
            return base.dameNombre() + " " + Sexo;
        }
        public string dameNombre(string tratamiento) {
            return tratamiento + " " + base.dameNombre() + " " + Sexo;
        }

        public override string QueEres { get { return "Soy un profesor"; } }
    }

    public class ProfesoEmerito : Profesor {
        public override bool EsValido() {
            Edad = -1;
            return Edad > 67 && base.EsValido();
        }
    }
    public class Alumno : Persona {
        private List<String> asignaturas;

        public Decimal Nota { get; set; } = 0;

        public new string QueEres { get { return "Soy un alumno"; } }

        public List<string> Asignaturas { 
            get => asignaturas; 
            set => asignaturas = value; 
        }
        public string this[int indice] {
            get {
                return asignaturas[indice];
            }
            set {
                if (asignaturas == null)
                    asignaturas = new List<string>();
                if (asignaturas.Count <= indice)
                    asignaturas.Add(value);
                else
                    asignaturas[indice] = value;
            }
        }
        public string this[int indice, string algo] {
            get {
                return asignaturas[indice] + algo;
            }
            
        }

        public override bool EsValido() {
            throw new NotImplementedException();
        }

        public void HacerExamen() { }
    }

    public class Empleado : Persona {
        public override bool EsValido() {
            throw new NotImplementedException();
        }
    }
}
