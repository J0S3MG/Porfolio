using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{
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
