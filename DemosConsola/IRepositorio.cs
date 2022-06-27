using DemosConsola.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemosConsola {
    public interface IRepositorio {
        List<Persona> DameTodos();
        Persona DameUno(int id);
        void Añade(Persona persona);
        void Modifica(Persona persona);
        void Borrar(int id);
    }

    public interface IConsulta {
        List<Persona> DameTodos();
        Persona DameUno(int id);
    }
    public interface IModifica {
        void Añade(Persona persona);
        void Modifica(Persona persona);
        void Borrar(int id);
    }
    public interface ICRUD: IConsulta, IModifica {

    }

}
