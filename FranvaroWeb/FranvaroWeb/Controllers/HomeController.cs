
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FranvaroWeb.Controllers
{
    public class HomeController : Controller
    {
        
        FranvaroServiceReferance.AnmalanService1Client klient = new FranvaroServiceReferance.AnmalanService1Client(); //Kopplar med e-tjänst och kan hämta metod som hämtar info från databas.


        // GET: Home
        public ActionResult Index(int id)
        {


            List<FranvaroServiceReferance.FranvaroDB> HistorikLista = klient.getAnmalan().ToList();

            FranvaroWeb.PersonalDBEntities db = new PersonalDBEntities();
            var pLista = db.PersonalLista.ToList();

            FranvaroServiceReferance.StatusLista stLista = new FranvaroServiceReferance.StatusLista();
            var test = klient.getStatusLista(id).ToList();

            ViewBag.ListOfStatus = test;

           

            //foreach (var item in test)
            //{

            //    ViewBag.hej = new List<string>() { "Referens ID: " +
            //        item.ReferensID.ToString(),  "Förnamn: " +
            //        item.fNamn, "Frånvaro orsak: " +
            //        item.FranvaroOrsak, "Status: " +
            //        item.Status, "Datum: " +
            //        item.Datum, "Tid: " +
            //        item.Tid  };


            //}

            //for (int i = 0; i < test.Count(); i++)
            //{
            //    ViewBag.hej = new List<string>() { "Referens ID: " +
            //        test[i].ReferensID.ToString(),  "Förnamn: " +
            //        test[i].fNamn, "Frånvaro orsak: " +
            //        test[i].FranvaroOrsak, "Status: " +
            //        test[i].Status, "Datum: " +
            //        test[i].Datum, "Tid: " +
            //        test[i].Tid  };

            //}

            //List<string> hej = new List<string>();
            //for (int i = 0; i < test.Count(); i++)
            //{
            //    stLista.fNamn = test[i].fNamn;
            //  //  stLista.ReferensID = test[i].ReferensID;
            //    stLista.Datum = test[i].Datum;
            //    stLista.Tid = test[i].Tid;
            //    stLista.Status = test[i].Status;
            //    stLista.FranvaroOrsak = test[i].FranvaroOrsak;

            //}

           // ViewBag.hej = stLista;


//            ViewBag.hej = klient.getStatusLista(id).ToList();
  //          Session["List"] = klient.getStatusLista(id).ToList();
            
            for (int i = 0; i < pLista.Count(); i++)
            {
                if (pLista[i].AnställningsID == id)
                {

                    return View(pLista[i]);
                }
            }


            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Index(PersonalLista pLista, string franOrskIn, string tidIn, string datumIn, string datumUt, string statusIn)
        {

            string namnet = pLista.Enamn;
            int nummer = int.Parse(pLista.Telefonnummer);

            string datum = datumIn + " - " + datumUt;
            

            klient.sparaStatus(pLista.Fnamn, pLista.Enamn, "FyllIAdress", nummer, pLista.E_mail, pLista.AnställningsID, franOrskIn, tidIn, datum, statusIn);

            FranvaroWeb.PersonalDBEntities db = new PersonalDBEntities();
            var pLista2 = db.PersonalLista.ToList();
            for (int i = 0; i < pLista2.Count(); i++)
            {
                if (pLista2[i].AnställningsID == pLista.AnställningsID)
                {
                    return RedirectToAction("Index", "Home", new { id = pLista.AnställningsID });
                }
              
            }
            return RedirectToAction("Index", "Login");


        }
        //[HttpPost]
        //public ActionResult Index(int AnställningsID)
        //{
        //    List<AnmalanServiceReferance.FranvaroDB> HistorikLista = klient.getAnmalan().ToList();
        //    if(AnställningsID != null)
        //    {

        //        HistorikLista = klient.getSpecificAnmalan(AnställningsID).ToList();

        //    }

        //    return View(HistorikLista);
        //}




    }
}