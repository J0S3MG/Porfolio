using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCliente.Validaciones
{
    public class DniInvalidoException : ApplicationException
    {
        public DniInvalidoException() : base("Dni Invalido") { }
        public DniInvalidoException(string message) : base(message) { }
        public DniInvalidoException(string message, Exception e) : base(message, e) { }

    }
}
