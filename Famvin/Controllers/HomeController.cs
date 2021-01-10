using Famvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Famvin.Controllers
{
    public class HomeController : Controller
    {
        FamVinEntities db = new FamVinEntities();

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Distribution()
        {
            return View();
        }

        public ActionResult GetCountryMembers()
        {
            var totals = from m in db.Member
                         join c in db.Council on m.IdCouncil equals c.IdCouncil
                         join cc in db.Country on c.IdCountry equals cc.IdCountry
                         group m by new
                         {
                             cc.IdCountry,
                             cc.Name, 
                             cc.HighMapCode
                         }
                         into grouped
                         select new
                         {
                             Country = grouped.Key.HighMapCode,
                             TotalMembers = grouped.Count()
                         };

            return Json(totals, JsonRequestBehavior.AllowGet);
        }

    }
}