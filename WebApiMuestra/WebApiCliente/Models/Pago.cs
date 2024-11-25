using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCliente.Models
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
