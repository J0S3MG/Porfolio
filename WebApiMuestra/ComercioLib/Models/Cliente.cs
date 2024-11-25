using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Esta carpeta junto con la carpeta Services forman el dominio del problema.
namespace ComercioLib.Models
{   //Siguiendo el UML creo la clase cliente la cual no representa un cliente perse sino un ticket o turno.
   //Que se carga en el sstema para que luego sea atendido.
    public class Cliente: Ticket
    { //Creo dos variables una va a almacenar el valor del DNI y la otra actualiza el numero del turno el numero del turno.
        private static int nroInicio;
        private int dni;
        public Cliente(string dni)
        {
            #region Hago el manejo de la excepcion.
            string patron = @"^d/{8}$";
            if (Regex.Match(dni, patron).Success==false)
            {
                throw new DniInvalidoException();
            }
            else
            {
                this.dni = Convert.ToInt32(dni);
                if (this.dni < 3000000 && this.dni > 45000000)
                {
                    throw new DniInvalidoException();
                }
            }
            #endregion
            nrO = nroInicio++;
        }
        public int VerDNI()
        {
            return dni;
        }

    }
}
