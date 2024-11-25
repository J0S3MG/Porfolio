using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{
    public class Pago: Ticket
    {
        private static int nroInicio;
        private CtaCte ficha;

        public Pago(CtaCte ficha)
        {
            this.ficha=ficha;
            nrO = nroInicio++;
        }
        public CtaCte VerCC()
        {
            return ficha;
        }
    }
}
