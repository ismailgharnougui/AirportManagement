using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.Web.Controllers
{
    public class FlightController : Controller
    {
        // GET: FlightController


        //1-  creation de l'instance ServiceFlight
        IServiceFlight serviceFlight;
        IServicePlane servicePlane;

        public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }

        //2 injection par constructeur

        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)

                return View(serviceFlight.GetAll());

            else
                return View(serviceFlight.GetMany(p => p.FlightDate.Equals(dateDepart)));
            
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.PlaneList = new SelectList(servicePlane.GetAll(), "PlaneId", "Capacity");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection)
        {
            try
            {
                serviceFlight.Add(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
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
