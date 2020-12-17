using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Famvin.Models;

namespace Famvin.Controllers
{
    public class DistributionController : Controller
    {
        private FamVinEntities db = new FamVinEntities();
        public ActionResult GetCountryMembers()
        {
            var totals = from m in db.Member
                         join c in db.Council on m.IdCouncil equals c.IdCouncil
                         join cc in db.Country on c.IdCountry equals cc.IdCountry
                         group m by new
                         {
                             cc.IdCountry,
                             cc.Name
                         }
                         into grouped
                         select new
                         {
                             Country = grouped.Key.Name,
                             TotalMembers = grouped.Count()
                         };

            return Json(totals, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPositionMembers()
        {
            var totals = from m in db.Member
                         join p in db.Position on m.IdPosition1 equals p.IdPosition
                         group m by new
                         {
                             p.IdPosition,
                             p.Name
                         }
                         into grouped
                         select new
                         {
                             Position = grouped.Key.Name,
                             TotalMembers = grouped.Count()
                         };

            return Json(totals, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRegionMembers()
        {
            var totals = from m in db.Member
                         join r in db.Region on m.IdRegion equals r.IdRegion
                         group m by new
                         {
                             r.IdRegion,
                             r.Name
                         }
                         into grouped
                         select new
                         {
                             Region = grouped.Key.Name,
                             TotalMembers = grouped.Count()
                         };

            return Json(totals, JsonRequestBehavior.AllowGet);
        }
    }
}