using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FranvaroWeb.Controllers
{
    public class AnställdHistorikController : Controller
    {

        FranvaroServiceReferance.AnmalanService1Client klient = new FranvaroServiceReferance.AnmalanService1Client();

        // GET: AnställdHistorik
        public ActionResult Index(int id)
        {
            List<FranvaroServiceReferance.FranvaroDB> test = new List<FranvaroServiceReferance.FranvaroDB>();

            test = klient.getSpecificAnmalan(id).ToList();
         

            
            int a = id;
            return View(test);
        }
    }
}