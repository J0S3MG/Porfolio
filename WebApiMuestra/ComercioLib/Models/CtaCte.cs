using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{
    public class CtaCte: IComparable
    {
        int nro;
        Cliente c;
        double saldo;
        public CtaCte(int nro, Cliente c)
        {
            this.nro = nro;
            this.c = c;
        }
        public int CompareTo(Object obj)
        {
            CtaCte cc = obj as CtaCte;
            if (cc != null)
            {
                return nro.CompareTo(cc.nro);
            }
            return 1;
        }
    }
}
