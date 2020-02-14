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

            bool ScriptValidation = test(ansID,Password);

            if (ScriptValidation == true)
            {
                for (int i = 0; i < funka.Count(); i++)
                {
                    if (funka[i].Fnamn.ToLower() == ansID.ToLower() && funka[i].Lösenord.ToLower() == Password.ToLower())
                    {
                        return RedirectToAction("Index", "Home", new { id = funka[i].AnställningsID });

                    }
                }
            }

            return RedirectToAction("Index");
        }

        public  bool test(string username,string password)
        {
            char[] charUsername = username.ToCharArray();
            char[] charPassword = password.ToCharArray();


            for (int i = 0; i < username.Length; i++)
            {
                if (charUsername[i] == '<' || charUsername[i] == '=' || charUsername[i] == '>' || charUsername[i] == '*' || charUsername[i] == '!' || charUsername[i] == '&' || charUsername[i] == '(' || charUsername[i] == '/') 
                {
                    username = null;
                    password = null;
                    return false;
                   
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (charPassword[i] == '<' || charPassword[i] == '=' || charPassword[i] == '>' || charPassword[i] == '*' || charPassword[i] == '!' || charPassword[i] == '&' || charPassword[i] == '(' || charPassword[i] == '/')
                {
                    username = null;
                    password = null;
                    return false;

                }
            }
            return true;
        }
    }
}