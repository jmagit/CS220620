using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemosConsola {

    [Serializable]
    public class CursoException : Exception {
        public CursoException(string message) : base(message) { }
        public CursoException(string message, Exception inner) : base(message, inner) { }
        protected CursoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
