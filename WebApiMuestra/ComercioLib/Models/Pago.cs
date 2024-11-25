using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{
    public class Pago: Ticket //Esta clase tambien hereda de ticket y nos permite gestionar los turnos de pago.
    {//Aqui recibimos una cuenta corriente sobre la cual se realizara el pago, aunque recordemos esta clase representa un turno.
        private static int nroInicio;//Por ende nos sirve para saber sobre que CtaCte se realiza el pago.
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
