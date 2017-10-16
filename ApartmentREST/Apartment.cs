using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ApartmentREST
{
    public class Apartment
    {
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public int Story { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Size { get; set; }
        [DataMember]
        public int NoOfRooms { get; set; }
        [DataMember]
        public int ZipCode { get; set; }

        public Apartment()
        {

        }
        
    }
}