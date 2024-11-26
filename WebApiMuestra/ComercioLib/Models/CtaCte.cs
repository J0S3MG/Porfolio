using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{
    public class CtaCte: IComparable//Aplicamos IComparable para poder buscar por numero de cuenta.
    {
        int nro;
        Cliente c;
        double saldo;
        public CtaCte(int nro, Cliente c)
        {
            this.nro = nro;
            this.c = c;
        }
        #region Como trabjamos con atributos privados para acceder a sus valores creamos metodos que nos retornan eso valores.
        public int VerNro()
        {
            return nro;
        }
        public Cliente VerTitular()
        {
            return c;
        }
        public double VerSaldo()
        {
            return saldo;
        }
        public void ActualizarSaldo(double s)
        {
            saldo = s;
        }
        #endregion
        public int CompareTo(Object obj)//Hacemos la comparacion por numero de cuenta.
        {
            CtaCte cc = obj as CtaCte;
            if (cc != null)
            {
                return nro.CompareTo(cc.VerNro());
            }
            return 1;
        }
    }
}
