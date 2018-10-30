using System.Linq;
using System.Web.Mvc;
using Hangfire;
using Microsoft.AspNet.Identity;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    public class MonitoringController : Controller
    {
        private readonly MonitoringRepository _monitoringRepository;

        public MonitoringController()
        {
            _monitoringRepository = new MonitoringRepository();
        }
        // GET: Monitoring
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            var monitorings = _monitoringRepository.GetAll();
            var userId = User.Identity.GetUserId();
            ViewBag.Railway = monitorings.FindAll(i => i.Type == MonitoringType.Railway && i.UserId == userId);
            ViewBag.Bus = monitorings.FindAll(i => i.Type == MonitoringType.Bus && i.UserId == userId);
            ViewBag.Blablacar = monitorings.FindAll(i => i.Type == MonitoringType.Blablacar && i.UserId == userId);
            return View();
        }

        // GET: Monitoring/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Monitoring/Create
        [HttpPost]
        public ActionResult Create(Monitoring monitoring)
        {
            try
            {
                monitoring.UserId = User.Identity.GetUserId();
                monitoring = _monitoringRepository.Create(monitoring);
                RecurringJob.AddOrUpdate(monitoring.Id.ToString() ,() => HangfireService.CheckTickets(monitoring), Cron.Minutely);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Monitoring/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Monitoring/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Monitoring/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Monitoring/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
