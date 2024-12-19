using ComercioLib.DTOs;
using ComercioLib.Models;
using ComercioLib.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        readonly static ComercioService comercio = new ComercioService();

        [HttpPost("AgregarTicket")]
        public IActionResult PostAgregarTicket(int tipo, string dni, int nroCC)
        {
            Ticket turno = null;
            try
            {
                if (tipo == 1)
                {
                    turno = new Cliente(dni);
                }
                else if (tipo == 2)
                {
                    CtaCte c = comercio.VerCtaCte(nroCC);
                    if (c != null)
                    {
                        turno = new Pago(c);
                    }
                    else
                    {
                        return NotFound("No encontro la cuenta corriente");
                    }
                }
                comercio.AgregarTicket(turno);
                return Ok("Se cargo correctamente el turno");
            }
            catch (DniInvalidoException d)
            {
                return BadRequest("Error al cargar el DNI: "+ d.Message);
            }
        }

        [HttpPost("AgregarCuentaCorriente")]
        public IActionResult PostAgregarCuentaCorriente(int nroCC, string dni, double saldo)
        {
            CtaCte cc = comercio.AgregarCtaCte(nroCC, dni);
            cc.ActualizarSaldo(saldo);
            if (cc != null) return Ok("La cuenta fue agregada");
            return Ok("La cuenta fue actualizada");
        }

        [HttpDelete("AtenderTicket")]
        public IActionResult DeleteAtenderTicket(int tipo)
        {
            Ticket t = comercio.AtenderTicket(tipo);
            if (t != null)
            {
                TicketDTO turno = new TicketDTO(t);
                return Ok(turno);
            }
            return NotFound("El ticket no existe");
        }

        [HttpGet("ListarAtendidos")]
        public IActionResult GetListaAtendidos()
        {
            List<Ticket> atendidos = comercio.VerAtendidos();
            for(int n = 0; n < atendidos.Count;n++)
            {   
                Ticket t = atendidos[n];
                TicketDTO t2 = new TicketDTO(t);
                return Ok(t2);
            }
            return NotFound("No hay tickets atendidos");
        }



    }
}
