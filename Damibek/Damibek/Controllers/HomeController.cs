using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Damibek.DAL;
using Damibek.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

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
            About model = new About();
            return View(model);
        }

        public ActionResult Services()
        {
            Services model = new Services();
            return View(model);
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
            Contact model = new Contact();
            model.message = new Message();

            return View(model);
        }

        [HttpGet]
        public ActionResult Solution(int? id)
        {
            Solution model = new Solution(id.ToString());
            return View(model);
        }


        [HttpGet]
        public ActionResult _Message()
        {
            Message model = new Message();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> _Message(Message model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var msg = new MailMessage( "gdc7@yandex.ru"
                                             , "be04@yandex.ru"
                                             , "GOODDEAL " + model.name
                                             , model.message
                                             );
                    var smtpClient = new SmtpClient("smtp.yandex.ru", 25);
                    smtpClient.Credentials = new NetworkCredential("gdc7@yandex.ru", "gd28042017");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(msg);
                    return Json(new { ok = true, newurl = Url.Action("Index") });
                }
                catch (Exception ex)
                {
                    string sMsg = "Class Exception=Exception; ";
                    sMsg = sMsg + "TargetSite=" + ex.TargetSite + "; Message=" + ex.Message + "; StackTrace=" + ex.StackTrace;
                    model.messageError = sMsg;
                    //throw ex;
                }
            }
            var jsonModel1 = JsonConvert.SerializeObject(model);
            return Json(jsonModel1, JsonRequestBehavior.AllowGet);
            /*
               Нужно реализовать отправку почты и сохранение в БД.
            */
            //int y = 10 - 10;
            //int x = 10 / y;
            //return Json(new { ok = true, newurl = Url.Action("Index") });
        }


        [HttpGet]
        public JsonResult GetProjects(string type)
        {
            Portfolio model = new Portfolio();
            if (type != "all")
            model.Projects = model.Projects.Where(m => m.projectType == type).ToList();

            var jsonModel = JsonConvert.SerializeObject(model);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }


    }
}