using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebAppServer.Models;
using WebAppServer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppServer.ApiCotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoService servicio;
        
        public AlumnoController(AlumnoService servicio)
        {
            this.servicio = servicio;
        }

        #region Caso GetAll.
        // GET: api/<AlumnoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var a = await servicio.GetAll();
            return Ok(a);
        }
        #endregion
        #region Caso GetById.
        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var a = await servicio.GetById(id);
            if(a != null)
            {
                return Ok(a);
            }
           return NotFound("No se encontro el alumno");
        }
        #endregion
        #region Caso Insert.
        // POST api/<AlumnoController>
        [HttpPost]
        public async Task<IActionResult> PostInsert([FromBody] Alumno value)
        {
            var a =  await servicio.Insert(value);
            if(a != false)
            {
                return Ok(a);
            }
            return BadRequest("No se pudo completar la operacion");
        }
        #endregion
        #region Caso Update.
        // PUT api/<AlumnoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Alumno value)
        {
            var a = await servicio.Update(value);
            if (a != false)
            {
                return Ok(a);
            }
            return BadRequest("No se pudo completar la operacion");
        }
        #endregion
        #region Caso Delete.
        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var a = await servicio.Delete(id);
            if (a != false)
            {
                return Ok(a);
            }
            return BadRequest("No se pudo completar la operacion");
        }
        #endregion
    }
}
