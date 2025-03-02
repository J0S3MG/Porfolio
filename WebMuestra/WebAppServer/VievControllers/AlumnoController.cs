using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppServer.Controllers;
using WebAppServer.Models;
using WebAppServer.Services;

namespace WebAppServer.VievControllers
{
    public class AlumnoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AlumnoService servicio;

        public AlumnoController(ILogger<HomeController> logger, AlumnoService alumnoService)
        {
            _logger = logger;
            servicio = alumnoService;
        }
        #region Caso GetAll.
        // GET: AlumnoController
        public async Task<ActionResult> Index()
        {
            var alumno = await servicio.GetAll();
            return View(alumno);
        }
        #endregion
        #region Caso GetById.
        // GET: AlumnoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var alumno = await servicio.GetById(id);
            return View(alumno);
        }
        #endregion
        #region Caso Insert.
        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Alumno a)
        {
            try
            {
                await servicio.Insert(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
        #region Caso Update.
        // GET: AlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlumnoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Alumno actualizar)
        {
            try
            {
                await servicio.Update(actualizar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
        #region Caso Delete.
        // GET: AlumnoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlumnoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Alumno a)
        {
            try
            {   await servicio.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
