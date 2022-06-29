using DemosConsola.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemosConsola {
    public class PersonaRepositorio : IRepositorio<Persona, int>, IDisposable {
        public void Añade(Persona persona) {
            throw new NotImplementedException();
        }

        public void Borrar(int id) {
            throw new NotImplementedException();
        }

        public List<Persona> DameTodos() {
            throw new NotImplementedException();
        }

        public Persona DameUno(int id) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public void Modifica(Persona persona) {
            throw new NotImplementedException();
        }
    }
    public class PersonaMockRepositorio : IRepositorio<Persona, int> {
        public void Añade(Persona persona) {
            throw new NotImplementedException();
        }

        public void Borrar(int id) {
            throw new NotImplementedException();
        }

        public List<Persona> DameTodos() {
            throw new NotImplementedException();
        }

        public Persona DameUno(int id) {
            throw new NotImplementedException();
        }

        public void Modifica(Persona persona) {
            throw new NotImplementedException();
        }
    }

    public class PersonaDB : ICRUD {
        public void Añade(Persona persona) {
            throw new NotImplementedException();
        }

        public void Borrar(int id) {
            throw new NotImplementedException();
        }

        public List<Persona> DameTodos() {
            throw new NotImplementedException();
        }

        public Persona DameUno(int id) {
            throw new NotImplementedException();
        }

        public void Modifica(Persona persona) {
            throw new NotImplementedException();
        }
    }
}
