using System;
using System.Collections.Generic;
using System.Linq;
using HammerTime.Models;
using System.Web;
using System.Web.Mvc;

namespace HammerTime.Controllers
{
    public class HammerController : Controller
    {

        private HTContext db = new HTContext();
        // GET: Hammer
        public ActionResult Index()
        {
            var hammer = db.Hammers.ToList();
            return View(hammer);
        }
    }
}