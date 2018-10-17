using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminAccountControl.Models;

namespace AdminAccountControl.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private readonly ApplicationDbContext _context;

        public AdminController()
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ControlPanel()
        {            
            return View();
        }

        public ActionResult Settings()
        {
            return View(_context.Settings.Single());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSettings(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View("Settings", setting);
            }

            var settingInDb = _context.Settings.Single();
            settingInDb.Map(setting);

            _context.SaveChanges();

            return RedirectToAction("Settings");
        }
    }
}