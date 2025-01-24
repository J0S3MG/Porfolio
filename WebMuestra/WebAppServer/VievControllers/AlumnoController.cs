using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppServer.Models;
using WebAppServer.Services;

namespace WebAppServer.VievControllers
{
    public class AlumnoController : Controller
    {
        static AlumnoService servicio = new AlumnoService();
        #region Caso GetAll.
        // GET: AlumnoController
        public ActionResult Index()
        {
            return View(servicio.GetAll());
        }
        #endregion

        // GET: AlumnoController/Details/5
        public ActionResult Details(int id)
        {
            return View(servicio.GetById(id));
        }

        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alumno a)
        {
            try
            {
                servicio.Insert(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlumnoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlumnoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
