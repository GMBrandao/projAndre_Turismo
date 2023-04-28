using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using projAndre_Turismo.Controllers;
using projAndre_Turismo.Models;

namespace projAndre_Turismo.Services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\gabri\OneDrive\Documentos\Aulas C#\projAndre_Turismo\Database\Travel.mdf;";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Hotel hotel)
        {
            bool status = false;

            try
            {
                string strInsert = "INSERT into Hotel (Name, IdAddress, Value, RegisterDate) " +
                    "values (@Name, @IdAddress, @Value, @RegisterDate)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                Address address = new();
                address = hotel.Address;

                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", new AddressController().FindAddress(address)));
                commandInsert.Parameters.Add(new SqlParameter("@Value", hotel.Value));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", hotel.RegisterDate));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public List<Hotel> FindAll()
        {

            List<Hotel> hotels = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select h.Id, h.Name, h.Value, h.IdAddress, a.Street, a.Number, a.Neighborhood, a.ZipCode, ");
            sb.Append("a.Complement, a.IdCity, ct.Description, h.RegisterDate from Hotel h, Address a, City ct ");
            sb.Append("WHERE a.IdCity = ct.Id AND a.Id = h.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel hotel = new();
                Address address = new();
                City city = new();

                hotel.Id = (int)dr["Id"];
                hotel.Name = (string)dr["Name"];
                hotel.Value = (double)(decimal)dr["Value"];
                hotel.RegisterDate = (DateTime)dr["RegisterDate"];

                address.Id = (int)dr["IdAddress"];
                address.Street = (string)dr["Street"];
                address.Number = (int)dr["Number"];
                address.Neighborhood = (string)dr["Neighborhood"];
                address.ZipCode = (string)dr["ZipCode"];
                address.Complement = (string)dr["Complement"];

                city.Id = (int)dr["IdCity"];
                city.Description = (string)dr["Description"];

                address.City = city;
                hotel.Address = address;

                hotels.Add(hotel);
            }
            return hotels;
        }

        public int FindHotel(Hotel hotel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select cast(h.Id as int) from Hotel h ");
            sb.Append("WHERE h.Name = @Name AND h.Value = @Value AND h.IdAddress = @Address");

            SqlCommand commandSelect = new(sb.ToString(), conn);

            Address address = hotel.Address;

            commandSelect.Parameters.Add(new SqlParameter("@Name", hotel.Name));
            commandSelect.Parameters.Add(new SqlParameter("@Value", hotel.Value));

            commandSelect.Parameters.Add(new SqlParameter("@Address", new AddressController().FindAddress(address)));
            //commandSelect.Parameters.Add(new SqlParameter("@Street", address.Street));
            //commandSelect.Parameters.Add(new SqlParameter("@Number", address.Number));
            //commandSelect.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            //commandSelect.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
            //commandSelect.Parameters.Add(new SqlParameter("@CityDescription", city.Description));
            //commandSelect.Parameters.Add(new SqlParameter("@Complement", address.Complement));


            return (int)commandSelect.ExecuteScalar();
        }
    }
}
