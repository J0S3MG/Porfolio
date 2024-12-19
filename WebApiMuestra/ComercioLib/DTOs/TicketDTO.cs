using ComercioLib.Models;
//La carpeta DTOs almacena clases que nos sirven para remapear nuestro modelo a otros sitios. Ej: swagger.
namespace ComercioLib.DTOs
{
    public class TicketDTO//Esta clase nos sirve para "desarmar o mapear" un objeto Ticket.
    {
        #region Las variables que sirven para guardar los valores del ticket.
        public string tipo { get; set; }//En este caso el tipo nos ayuda a distinguir si es un Cliente o un Pago.
        public int nroOrden { get; set; }
        public DateTime fechaHora { get; set; }
        public CtaCteDTO ficha { get; set; }
        public int dni { get; set; }
        #endregion
        public TicketDTO(Ticket ticket)//En este costructor extraemos los valores del objeto que le pasemos.
        {
            nroOrden = ticket.VerNroOrden();
            fechaHora = ticket.VerFechaHora();
            //Como la herecia no puede mantenerse cuando se "desarma o mapea" asi que utilizamos una variable llamada tipo.
            if (ticket is Cliente c)//La cual nos permitira saber si es un Ciente o un Pago.
            {
                tipo = "Cliente";
                this.dni = c.VerDNI();
            }
            else if (ticket is Pago p)
            {
                tipo = "Pago";
                ficha = new CtaCteDTO(p.VerCC());
            }
        }
    }
}
