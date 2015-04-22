using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncleChao.CompanyManagerment.BLL;
using UncleChao.CompanyManagerment.IBLL;
using UncleChao.CompanyManagerment.Model;

namespace UncleChao.UI.CompanyManagerment.Controllers
{
    public class ExperienceController : Controller
    {
        private IExperienceService experienceService = new ExperienceService();

        //
        // GET: /Experience/

        public ActionResult Index()
        {
            return View(experienceService.GetAllEmployees().AsEnumerable());
        }

        //
        // GET: /Experience/Details/5

        public ActionResult Details(int id = 0)
        {
            Experience experience = experienceService.GetEmployeeById(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        //
        // GET: /Experience/Create

        public ActionResult Create()
        {
            //ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "Name");
            return View();
        }

        //
        // POST: /Experience/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experienceService.InsertExperience(experience);
                return RedirectToAction("Index");
            }

            //ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "Name", experience.EmployeeId);
            return View(experience);
        }

        //
        // GET: /Experience/Edit/5

        public ActionResult Edit(int id)
        {
            Experience experience = experienceService.GetEmployeeById(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "Name", experience.EmployeeId);
            return View(experience);
        }

        //
        // POST: /Experience/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experienceService.UpdateExperience(experience);
                return RedirectToAction("Index");
            }
            //ViewBag.EmployeeId = new SelectList(db.EmployeeSet, "Id", "Name", experience.EmployeeId);
            return View(experience);
        }

        //
        // GET: /Experience/Delete/5

        public ActionResult Delete(int id)
        {
            Experience experience = experienceService.GetEmployeeById(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        //
        // POST: /Experience/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            experienceService.DeleteExperienceById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            //base.Dispose(disposing);
        }
    }
}