using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminAccountControl.Models;

namespace AdminAccountControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_context.Appliances.ToList());
        }

        [HttpPost]
        public ActionResult GetApplianceForm(int id)
        {
            var viewModel = new ApplianceViewModel(id);
            return PartialView("_ApplianceForm", viewModel);
        }

        [HttpPost]
        public ActionResult ConfirmDeleteAppliance(int id)
        {
            var appliance = _context.Appliances.Single(q => q.Id == id);

            return PartialView("_ConfirmDelete", appliance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppliance(int id)
        {
            var applianceInDb = _context.Appliances.Single(q => q.Id == id);

            _context.Appliances.Remove(applianceInDb);
            _context.SaveChanges();

            return PartialView("_ApplianceList", _context.Appliances.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Appliance appliance)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                return PartialView("_ApplianceForm", new ApplianceViewModel(appliance.Id));
            }

            if (appliance.Id == 0)
            {
                _context.Appliances.Add(appliance);
            }
            else
            {
                var applianceInDb = _context.Appliances.Single(q => q.Id == appliance.Id);
                applianceInDb.Map(appliance);
            }

            _context.SaveChanges();

            return PartialView("_ApplianceList", _context.Appliances.ToList());
        }





















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}