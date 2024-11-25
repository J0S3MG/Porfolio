using ComercioLib.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiCliente.Validaciones
{
    public class ControlValidaciones
    {
        public bool ValidarDNI(string dni)
        {
            string patron = @"^d/{8}$";
            if (Regex.Match(dni, patron).Success==false)
            {
                throw new DniInvalidoException();
                return false;
            }
            else
            {
                int d = Convert.ToInt32(dni);
                if (d < 3000000 && d > 45000000)
                {
                    throw new DniInvalidoException();
                    return false;
                }
                return true;
            }
        }
    }
}
