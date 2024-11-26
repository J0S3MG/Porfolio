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
            string patron = @"^\d{8}$";
            if (Regex.IsMatch(dni, patron) == false)
            {
                throw new DniInvalidoException();
            }
            else
            {
                int d = Convert.ToInt32(dni);
                if ( d <= 3000000 || d >= 45000000)
                {
                    throw new DniInvalidoException();
                }
                this.dni = d;
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
