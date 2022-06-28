using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemosConsola.Entidades {
    public partial class Profesor {
        public bool Validar() {
            try {
                ValidaNombre();
                ValidaApellidos();
            } catch {
                return false;
            }
            return true; 
        }
        partial void ValidaNombre();
        partial void ValidaApellidos();
    }
}

