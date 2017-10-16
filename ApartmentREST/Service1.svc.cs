using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ApartmentREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //Data Source=natascha.database.windows.net;Initial Catalog=School;Integrated Security=False;User ID=nataschajakobsen;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private string connStr = "Server=tcp:natascha.database.windows.net,1433;Initial Catalog = School; Persist Security Info=False;User ID = nataschajakobsen; Password= Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        //laver en ny liste
        List<Apartment> apartments = new List<Apartment>();

        public Apartment AddApartment(Apartment lejlighed)
        {
            //this.apartments.Add(lejlighed);
            //apartments.Add(addlejlighed);

            if (lejlighed == null)
                throw new ArgumentNullException("lejlighed");
            apartments.Add(lejlighed);
            return lejlighed;
        }





        /// <summary>
        /// Printer alle lejligheder ud når den køres (fra databasen)
        /// </summary>
        /// <returns></returns>
        public IList<Apartment> GetAllApartment()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                //åbner for forbindelsen
                connection.Open();

                //laver en sql command som vælger alt fra tabellen Apartment og sorterer i form af ID
                String sql = "SELECT * FROM dbo.Apartment order by Id";

                SqlCommand command = new SqlCommand(sql, connection); //// create a command object
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Apartment newapartment = new Apartment();

                    newapartment.ID = reader.GetInt32(0);
                    newapartment.Size = reader.GetInt32(1);
                    newapartment.NoOfRooms = reader.GetInt32(2);
                    newapartment.Story = reader.GetInt32(3);
                    newapartment.ZipCode = reader.GetInt32(4);
                    newapartment.Adress = reader.GetString(5);
                    

                    apartments.Add(newapartment);
                }
            }

            //returnerer listen apartments
            return apartments;
        }


    }
}
