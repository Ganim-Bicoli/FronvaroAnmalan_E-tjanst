using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace E_projektService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAnmalanService1
    {

        [OperationContract]
        List<FranvaroDB> getAnmalan();
        [OperationContract]
        List<StatusLista> getStatusLista(int id);
        [OperationContract]
        List<FranvaroDB> getSpecificAnmalan(int id);
        [OperationContract]
        string sparaStatus(string fNamn, string eNamn, string adress, int Telefonnummer, string epost, int Anstallningsid, string franVaroOrsak, string tid, string datum, string status);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class FranvaroDB
    {
        [DataMember]
        public int ReferensID { get; set; }
        [DataMember]
        public string fNamn { get; set; }
        [DataMember]
        public string eNamn { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public int? Telefonnummer { get; set; }
        [DataMember]
        public string E_post { get; set; }
        [DataMember]
        public int AnstallningsID { get; set; }
        [DataMember]
        public string FranvaroOrsak { get; set; }
        [DataMember]
        public string Tid { get; set; }
        [DataMember]
        public string Datum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
    [DataContract]
    public class StatusLista
    {
        [DataMember]
        public int ReferensID { get; set; }
        [DataMember]
        public string fNamn { get; set; }
        [DataMember]
        public int AnstallningsID { get; set; }
        [DataMember]
        public string FranvaroOrsak { get; set; }
        [DataMember]
        public string Tid { get; set; }
        [DataMember]
        public string Datum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
