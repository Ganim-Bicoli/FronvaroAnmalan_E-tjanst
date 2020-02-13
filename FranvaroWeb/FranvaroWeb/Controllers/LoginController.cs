using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FranvaroWeb.Controllers
{

    public class LoginController : Controller
    {

        //List<Employe> db = new List<Employe>().ToList();


        // GET: Login
        public ActionResult Index()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult Index(string ansID, string Password)
        {
            FranvaroWeb.PersonalDBEntities db = new PersonalDBEntities();
            var funka = db.PersonalLista.ToList();



            for (int i = 0; i < funka.Count(); i++)
            {
                if(funka[i].Fnamn.ToLower() == ansID.ToLower() && funka[i].Lösenord.ToLower() == Password.ToLower())
                {
                    return RedirectToAction("Index", "Home", new { id = funka[i].AnställningsID });

                }
            }

            //foreach (var i in funka)
            //{
            //    if (i.Fnamn == ansID)  //TODO fixa inlogg åt användare, Anvnamn och Pass && i.Lösenord.ToLower() == Password.ToLower()
            //    {
            //        return RedirectToAction("Index", "Home", new { id = i.AnställningsID });
            //    }
            //}

            return View();
        }
    }
}