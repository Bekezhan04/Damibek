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
            Index model = new Index("Index");
            return View(model);
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

        [HttpGet]
        public ActionResult Solution(int? id)
        {
            Solution model = new Solution(id.ToString());
            model.test = "ddddddddddddddddd";
            return View(model);
        }


    }
}