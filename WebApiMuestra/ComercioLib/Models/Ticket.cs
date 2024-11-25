using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{//Esta clase nos sirve como representacion de los tickets que podamos tener en el sistema
//Los mismos puede ser de Pago o Cliente.
    public abstract class Ticket
    {
        protected int nrO;
        private DateTime fh;

        public int VerNroOrden()
        {
            return nrO;
        }
        public DateTime VerFechaHora()
        {
            return fh = DateTime.Now;
        }
    }
}
