using System.Collections.Generic;
using System.Web.Mvc;
using Hangfire;
using Microsoft.AspNet.Identity;
using test.Models.Railway;
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

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Monitoring monitoring)
        {
            try
            {
                monitoring.UserId = User.Identity.GetUserId();
                monitoring.UserEmail = User.Identity.GetUserName();
                monitoring = _monitoringRepository.Create(monitoring);
                RecurringJob.AddOrUpdate(monitoring.Id.ToString() ,() => HangfireService.CheckTickets(monitoring), Cron.Minutely);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var b = _monitoringRepository.Get(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            if (b.IsInProccess)
            {
                RecurringJob.RemoveIfExists(b.Id.ToString());
            }

            _monitoringRepository.Delete(b.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Finded()
        {
            return View();
        }
    }
}