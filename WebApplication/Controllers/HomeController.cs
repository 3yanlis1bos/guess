using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using GuessData.Helpers;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        
        }

        public ActionResult Guess(GuessModel model)
        {
            ViewBag.Message = "Truth will be spoken.";

            if (model.Person == null)
            {
                model = new GuessModel();

                string s = GuessData.DialogConstant.NAME_DEFAULT;
                using (var db = new GuessData.GuessEntities())
                {
                    int rand = new Random().Next(db.People.Count());
                    GuessData.People p = db.People.Find(rand);

                    s = p.Name ?? GuessData.DialogConstant.NAME_DEFAULT;

                    model.Person = p;
                }
            }
            else
            {
                if (model.Decision)
                {
                   CRUDSHelper.AddNewSuccess(model.Person.Id);
                }
            }
            

            return View(model);
        }

        

        public ActionResult NoFoolYourself()
        {
            ViewBag.Message = "Do not fool yourself.";

            return View();
        }

        public ActionResult NoSurprise()
        {
            Object id = 0;
            ViewData.TryGetValue("ID", out id);
            CRUDSHelper.AddNewSuccess((int)id);
            
            ViewBag.Message = "Truth never will be a suprise for the wise. And it wasn't a surprise last " +CRUDSHelper.GetSuccessCount().ToString()+" times";
            return View();
        }
    }
}
