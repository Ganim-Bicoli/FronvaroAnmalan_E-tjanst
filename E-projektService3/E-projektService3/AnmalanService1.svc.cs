using System.Collections.Generic;
using System.Linq;

namespace E_projektService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IAnmalanService1
    {
        List<FranvaroDB> Returdata = new List<FranvaroDB>();
        List<StatusLista> stLista = new List<StatusLista>();

        public List<FranvaroDB> getAnmalan()
        {
            using (AnmalanModel db = new AnmalanModel())
            {
                var dbFranvaroList = db.Franvaro.ToList();
                foreach (var i in dbFranvaroList)
                {
                    FranvaroDB returlist = new FranvaroDB();
                    returlist.ReferensID = i.ReferensID;
                    returlist.fNamn = i.fNamn;
                    returlist.eNamn = i.eNamn;
                    returlist.Adress = i.Adress;
                    returlist.Telefonnummer = i.Telefonnummer;
                    returlist.E_post = i.E_post;
                    returlist.AnstallningsID = i.AnstallningsID;
                    returlist.FranvaroOrsak = i.FranvaroOrsak;
                    returlist.Status = i.Status;
                    returlist.Tid = i.Tid;
                    returlist.Datum = i.Datum;
                    Returdata.Add(returlist);
                }
                return Returdata;

            }
        }

        public List<FranvaroDB> getSpecificAnmalan(int id)
        {

            using (AnmalanModel db = new AnmalanModel())
            {
                var dbFranvaroList = db.Franvaro.ToList();
                foreach (var i in dbFranvaroList)
                {
                    if (i.AnstallningsID == id)
                    {
                        FranvaroDB returlist = new FranvaroDB();
                        returlist.ReferensID = i.ReferensID;
                        returlist.fNamn = i.fNamn;
                        returlist.eNamn = i.eNamn;
                        returlist.Adress = i.Adress;
                        returlist.Telefonnummer = i.Telefonnummer;
                        returlist.E_post = i.E_post;
                        returlist.AnstallningsID = i.AnstallningsID;
                        returlist.FranvaroOrsak = i.FranvaroOrsak;
                        returlist.Status = i.Status;
                        returlist.Tid = i.Tid;
                        returlist.Datum = i.Datum;
                        Returdata.Add(returlist);
                        
                    }

                }
                return Returdata;

            }
        }

        public List<StatusLista> getStatusLista(int id)
        {
            using (AnmalanModel db = new AnmalanModel())
            {
                var dbFranvaroList = db.Franvaro.ToList();

                int visaAntalKolumn = 0;

                for (int i = dbFranvaroList.Where(x => x.AnstallningsID == id).Count(); i > 0; i--)
                {
                    

                    StatusLista templistan = new StatusLista();
                    templistan.ReferensID = dbFranvaroList[i].ReferensID;
                    templistan.fNamn = dbFranvaroList[i].fNamn;
                    templistan.FranvaroOrsak = dbFranvaroList[i].FranvaroOrsak;
                    templistan.Tid = dbFranvaroList[i].Tid;
                    templistan.Datum = dbFranvaroList[i].Datum;
                    templistan.Status = dbFranvaroList[i].Status;
                    stLista.Add(templistan);

                    visaAntalKolumn++;
                    if(visaAntalKolumn == 4)
                    {
                        break;
                    }


                }

                return stLista;

            }
        }


        //public List<FranvaroDB> getSpecificAnmalan(int id)
        //{
        //    using (AnmalanModel db = new AnmalanModel())
        //    {
        //        var dbFranvaroList = db.Franvaro.ToList();
        //        foreach (var i in dbFranvaroList)
        //        {
        //            if(i.AnstallningsID == id) {
        //                FranvaroDB returlist = new FranvaroDB();
        //                returlist.ReferensID = i.ReferensID;
        //                returlist.fNamn = i.fNamn;
        //                returlist.eNamn = i.eNamn;
        //                returlist.Adress = i.Adress;
        //                returlist.Telefonnummer = i.Telefonnummer;
        //                returlist.E_post = i.E_post;
        //                returlist.AnstallningsID = i.AnstallningsID;
        //                returlist.FranvaroOrsak = i.FranvaroOrsak;
        //                returlist.Status = i.Status;
        //                returlist.Tid = i.Tid;
        //                returlist.Datum = i.Datum;
        //                Returdata.Add(returlist);
        //                break;
        //            } 

        //        }
        //        return Returdata;

        //    }
        //}

        //public List<StatusLista> getStatusLista(int id)
        //{


        //    using (AnmalanModel db = new AnmalanModel())
        //    {


        //        var dbFranvaroList = db.Franvaro.ToList();

        //        for (int i = 0; i < 1; i++)
        //        {
        //            if (dbFranvaroList[i].AnstallningsID == id)
        //            {
        //                StatusLista templistan = new StatusLista();
        //                templistan.ReferensID = dbFranvaroList[i].ReferensID;
        //                templistan.fNamn = dbFranvaroList[i].fNamn;
        //                templistan.FranvaroOrsak = dbFranvaroList[i].FranvaroOrsak;
        //                templistan.Tid = dbFranvaroList[i].Tid;
        //                templistan.Datum = dbFranvaroList[i].Datum;
        //                templistan.Status = dbFranvaroList[i].Status;
        //                stLista.Add(templistan);

        //            }
        //        }                
        //        return stLista;

        //    }
        //}

        public string sparaStatus(string fNamnIn, string eNamn, string adress, int TelefonnummerIn, string epost, int Anstallningsid, string franVaroOrsak, string tid, string datum, string status)
        {

            string DefaultStatus = status;
            DefaultStatus = "Pågående";
            using (AnmalanModel db = new AnmalanModel())
            {
                Franvaro tempDBList = new Franvaro();  //TempLista av DB-variabler

                tempDBList.fNamn = fNamnIn;
                tempDBList.eNamn = eNamn;
                tempDBList.Adress = adress;
                tempDBList.Telefonnummer = TelefonnummerIn;
                tempDBList.E_post = epost;
                tempDBList.AnstallningsID = Anstallningsid;
                tempDBList.FranvaroOrsak = franVaroOrsak;
                tempDBList.Tid = tid;
                tempDBList.Datum = datum;
                tempDBList.Status = DefaultStatus;

                db.Franvaro.Add(tempDBList);

                db.SaveChanges();
            }
            return "det funkade";
        }
    }
}
