using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            return Ok(servicio.GetAll());
        }
        #endregion
        #region Caso GetById.
        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = servicio.GetById(id);
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
        public IActionResult PostInsert([FromBody] Alumno value)
        {
            var a =  servicio.Insert(value);
            if(a != null)
            {
                return Ok(a);
            }
            return BadRequest("No se pudo completar la operacion");
        }
        #endregion
        #region Caso Update.
        // PUT api/<AlumnoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Alumno value)
        {
          return Ok(servicio.Update(value));  
        }
        #endregion
        #region Caso Delete.
        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(servicio.Delete(id));
        }
        #endregion
    }
}
