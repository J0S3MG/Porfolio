using ComercioLib.Models;
//Esta carpeta junto con la carpeta Models forman el dominio del problema.
namespace ComercioLib.Services
{//Siguiendo el UML esta clase representaria la "Clase Contenedora", quien se encarga de hacer todo lo que el Dominio solicita.
    public class ComercioService
    {
        #region Listas y Colas
        Queue<Pago> nuevoP = new Queue<Pago>();
        Queue<Cliente> nuevoC = new Queue<Cliente>();
        List<CtaCte> ctaCtes = new List<CtaCte>();
        List<Ticket> atendidos = new List<Ticket>();
        #endregion
        public void AgregarTicket(Ticket t)//En este metodo agregamos un ticket a travez de herencia.
        {
            if (t is Cliente c)//Si t es un Cliente se asigna la referencia a c.
            {
                nuevoC.Enqueue(c);//Luego guardamos c en la cola.
            }
            else if (t is Pago p)//Si t es un Pago se asigna la referencia a p.
            {
                nuevoP.Enqueue(p);//Luego guardamos p en la cola.
            }
        }
        public Ticket AtenderTicket(int tipo)//En este metodo quitamos un ticket de la cola.                                      
        {                                   //Y lo guardamos en una lista de atendios.
            Ticket t = null;
            if (tipo == 1)
            {
                t = nuevoC.Dequeue();
            }
            else if (tipo == 2)
            {
                t = nuevoP.Dequeue();
            }
            atendidos.Add(t);//Lo guardamos en la lista de atendidos.
            return t;//Retornamos el ticket quitado para poder mostrarlo.
        }
        public CtaCte VerCtaCte(int nro)
        {//Buscamos una cuenta corriente por su numero.
            CtaCte cc = new CtaCte(nro, null);
            ctaCtes.Sort();
            int idx = ctaCtes.BinarySearch(cc);
            if (idx >= 0) return ctaCtes[idx];
            return null;
        }
        public CtaCte AgregarCtaCte(int nroCC, string dni)
        {//Agregamos una cuenta corriente.
            CtaCte cc = VerCtaCte(nroCC);
            if (cc == null)
            {
                Cliente c = new Cliente(dni);
                cc = new CtaCte(nroCC, c);
                ctaCtes.Add(cc);
                return cc;
            }
            return null;
        }
    }
}
