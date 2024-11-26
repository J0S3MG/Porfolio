using ComercioLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//La carpeta DTOs almacena clases que nos sirven para remapear nuestro modelo a otros sitios. Ej: swagger.
namespace ComercioLib.DTOs
{ 
    public class CtaCteDTO//Esta clase nos sirve para "desarmar o mapear" un objeto cuenta corriente.
    {
        #region Las variables que sirven para guardar los valores de la CtaCte.
        public int nroCuenta { get; set; }
        public int dni { get; set; }
        public double saldo { get; set; }
        #endregion
        public CtaCteDTO(CtaCte cc)//En este costructor extraemos los valores del objeto que le pasemos.
        {
            this.nroCuenta=cc.VerNro();

            if (cc.VerTitular() != null)
            {
                this.dni = cc.VerTitular().VerDNI();
            }
            saldo = cc.VerSaldo();
        }
    }
}
