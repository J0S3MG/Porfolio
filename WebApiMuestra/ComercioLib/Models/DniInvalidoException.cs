using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.Models
{   //Creamos una Excepcion personalizada para tratar el ingreso de los DNI en caso de que no los ingresen correctamente. 
    public class DniInvalidoException : ApplicationException
    {
        public DniInvalidoException() : base("Ingreso un caracter envez de un Nro.") { }
        public DniInvalidoException(string message) : base(message) { }
        public DniInvalidoException(string message, Exception e) : base(message, e) { }

    }
}
