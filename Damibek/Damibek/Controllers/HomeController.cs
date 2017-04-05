using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Damibek.DAL;
using Damibek.Models;

namespace Damibek.Controllers
{
    public class HomeController : Controller
    {
        Repository db;
        public HomeController()
        {
            db = new Repository();

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Portfolio()
        {
            Portfolio model = new Portfolio();
            model.Projects = db.GetProject();
            return View(model);

        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Solution(int? solution_id)
        {
            return View();
        }

    }
}